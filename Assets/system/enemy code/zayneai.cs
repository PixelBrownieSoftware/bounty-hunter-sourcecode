using UnityEngine;
using System.Collections;

public class zayneai : MonoBehaviour {


    private bool hurt;
    private float maxdelay = 0.2f;
    public float atkdelay;
    private float delay;
    public int hp;
    public int expadd;
    public int maxhp;
    public enemydamage user;
    public playerstats playertgt;

    private int dropchance;
    public GameObject enemydrop;
    public GameObject explsion;
    public GameObject hurtfx;

    private timecode levelgoing;
    private float timelimit;

    private sfxmanager sfxman;

    private SpriteRenderer zRenderer;
    public GameObject graphic;
    Animator anim;

    public float angle;

    public Transform target;
    public float speed;
    private Transform myTransform;
    public int gender;
    
    void Start()
    {
        dropchance = Random.Range(5, 7);
        levelgoing = GameObject.FindWithTag("Timer").GetComponent<timecode>();
        graphic = transform.Find("graphic (zayne)").gameObject;
        zRenderer = graphic.GetComponent<SpriteRenderer>();
        anim = graphic.GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        playertgt = FindObjectOfType<playerstats>();
        sfxman = FindObjectOfType<sfxmanager>();
        gender = Random.Range(1, 3);
        anim.SetInteger("gender", gender);

        //Random.Range(1, 2)

        myTransform = transform;
        hp = maxhp;
    }

    //this points the hitbox in the direction of the attack as well as activating it.

    //the function when the enemy's hitbox touches the player's attack hitbox
    public void HurtEnemy(int bulldmg)
    {
        if (delay <= 0f)
        {
            Instantiate(hurtfx, transform.position, transform.rotation);
            hp -= bulldmg;
            delay = maxdelay;
            sfxman.enemyHurt.Play();
        }

    }
    
    void Update()
    {
        timelimit = levelgoing.GetComponent<timecode>().timer;

        delay -= Time.deltaTime;
        atkdelay -= Time.deltaTime;

        Vector3 direction = target.position - transform.position;
        direction.Normalize();

        angle = Mathf.Atan2(direction.x, direction.y) * -Mathf.Rad2Deg;

        timelimit = levelgoing.GetComponent<timecode>().timer;
        if (timelimit <= 0)
        {
            Die();
        }

        //flashing red when hurt, the only thing we need now is some particle effects to get that statisfication of a hit
        if (delay >= 0)
        {

            SpriteRenderer renderer = graphic.GetComponent<SpriteRenderer>();
            renderer.color = new Color(11f, 0f, 0.5f, 1f); // Set to red
        }
        else
        {
            SpriteRenderer renderer = graphic.GetComponent<SpriteRenderer>();
            renderer.color = new Color(1.5f, 1.5f, 1.5f, 1.5f);
        }

       if (Vector3.Distance(transform.position, target.position) >= 1.27f){

            if (angle <= -91 && angle >= -180 || angle >= 91 && angle <= 180)
            {
                //down
                anim.SetFloat("inp_y", -1);
            }
            if (angle <= -91 && angle >= -180 || angle >= 91 && angle <= 180)
            {
                //down
                transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
            }
            if (angle >= -91 && angle <= -1 || angle <= 91 && angle >= 0)
            {
                //up
                 anim.SetFloat("inp_y", 1);
            }
            if (angle >= -91 && angle <= -0 || angle <= 91 && angle >= 0)
            {
                //up
                transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            }
            if (angle >= 1 && angle <= 179)
            {
                //left
                anim.SetFloat("inp_x", -1);
            }
            if (angle >= 0 && angle <= 179)
            {
                //left
                transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
            }
            if (angle <= -1 && angle >= -179)
            {
                //right
                anim.SetFloat("inp_x", 1);
            }
            if (angle <= 0 && angle >= -179)
            {
                //right
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
        } 
       

            //kicks the bucket if hp = 0
        if (hp <= 0)
        {
            Instantiate(explsion, transform.position, transform.rotation);
            expadd = Random.Range(10, 15);
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
