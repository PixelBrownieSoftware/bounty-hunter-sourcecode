using UnityEngine;
using System.Collections;

public class goblinai : MonoBehaviour {

    public enum Actions { moving, reatreating, shooting }
    public Actions bossaction;

    public float aidelay;



    private bool hurt;
    private float maxdelay = 0.2f;
    private float delay;
    public int hp;
    public int expadd = 3;
    public int maxhp = 3;

    private int dropchance;
    public GameObject enemydrop;
    public GameObject explsion;
    public GameObject hurtfx;

    public enemydamage user;

    public timecode levelgoing;
    public float timelimit;

    private sfxmanager sfxman;

    public playerstats playertgt;

    private SpriteRenderer gRenderer;
    public GameObject graphic;

    Animator anim;

    private float rotspeed;
    public float angle;

    public Transform target;
    public float speed;
    private Transform myTransform;

    // Use this for initialization
    void Start()
    {
        levelgoing = GameObject.FindWithTag("Timer").GetComponent<timecode>();
        dropchance = Random.Range(1, 5);
        graphic = transform.Find("graphic (goblin)").gameObject;
        gRenderer = graphic.GetComponent<SpriteRenderer>();
        anim = graphic.GetComponent<Animator>();

        sfxman = FindObjectOfType<sfxmanager>();
        speed = 0.42f;
        target = GameObject.FindWithTag("Player").transform;
        playertgt = FindObjectOfType<playerstats>();
        myTransform = transform;
        hp = maxhp;
        bossaction = Actions.moving;
    }

    //this points the hitbox in the direction of the attack as well as activating it.
    public void Attack()
    {

    }

    //the function when the enemy's hitbox touches the player's attack hitbox
    public void HurtEnemy(int bulldmg)
    {
        if (delay <= 0f)
        {

            hp -= bulldmg;
            delay = maxdelay;
            aidelay = 1.5f;
            Instantiate(hurtfx, transform.position, transform.rotation);
            sfxman.enemyHurt.Play();
            Retreat();
        }
    }

    void Retreat()
    {
        if (aidelay >= 0.1)
        {
            bossaction = Actions.reatreating;
        }


    }

    // Update is called once per frame
    void Update()
    {
        timelimit = levelgoing.GetComponent<timecode>().timer;
        if (timelimit < 0.2)
        {
            Die();
        }


        aidelay -= Time.deltaTime;
        if (aidelay <= 0) { bossaction = Actions.moving; }
      


        Vector3 direction = target.position - transform.position;
        direction.Normalize();

        angle = Mathf.Atan2(direction.x, direction.y) * -Mathf.Rad2Deg;

        if (angle <= -91 && angle >= -180 || angle >= 91 && angle <= 180)
        {
            //down
            anim.SetFloat("inp_x", 0); anim.SetFloat("inp_y", -1);
        }
        if (angle <= -91 && angle >= -180 || angle >= 91 && angle <= 180)
        {
            //down
            transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
        }
        if (angle >= -91 && angle <= -1 || angle <= 91 && angle >= 0)
        {
            //up
            anim.SetFloat("inp_x", 0); anim.SetFloat("inp_y", 1);
        }
        if (angle >= -91 && angle <= -0 || angle <= 91 && angle >= 0)
        {
            //up
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }
        if (angle >= 1 && angle <= 179)
        {
            //left
            anim.SetFloat("inp_x", -1); anim.SetFloat("inp_y", 0);
        }
        if (angle >= 0 && angle <= 179)
        {
            //left
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (angle <= -1 && angle >= -179)
        {
            //right
            anim.SetFloat("inp_x", 1); anim.SetFloat("inp_y", 0);
        }
        if (angle <= 0 && angle >= -179)
        {
            //right
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        switch (bossaction)
        {
            case Actions.moving:

                speed = 0.3f;
                
                break;

            case Actions.reatreating:
                speed = 0.6f;
                break;

           
        }


        if (delay >= 0)
        {
            delay -= Time.deltaTime;
            SpriteRenderer renderer = graphic.GetComponent<SpriteRenderer>();
            renderer.color = new Color(11f, 0f, 0.5f, 1f); // Set to red
        }
        else
        {
            SpriteRenderer renderer = graphic.GetComponent<SpriteRenderer>();
            renderer.color = new Color(1.5f, 1.5f, 1.5f, 1.5f);
        }

        //kicks the bucket if hp = 0
        if (hp <= 0)
        {
            Instantiate(explsion, transform.position, transform.rotation);
            expadd = Random.Range(8, 15);
            playertgt.Addexp(expadd);


            if (dropchance == 2)
            {
                Instantiate(enemydrop, transform.position, transform.rotation);
            }
            Die();
        }


    }

    public void Die()
    {
        enemyspawn.enemycount--;
        Destroy(gameObject);

    }

}
