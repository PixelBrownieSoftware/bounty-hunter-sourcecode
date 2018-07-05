using UnityEngine;
using System.Collections;

public class slimeai : MonoBehaviour {

    private bool hurt;
    private float maxdelay = 0.2f;
    private float delay;
    public int hp;
    public int expadd = 3;
    public int maxhp = 3;
    private float timer;
    private int dropchance;
    public GameObject enemydrop;
    public GameObject explsion;
    public GameObject hurtfx;
    public GameObject gernade;

    public enemydamage user;

    private timecode levelgoing;
    private float timelimit;
    private sfxmanager sfxman;


    public playerstats playertgt;

    private SpriteRenderer sRenderer;
    public GameObject graphic;

    Animator anim;

    private float rotspeed;
    public float angle;

    public Transform target;
    public float speed;
    private Transform myTransform;
    
    void Start () {
        levelgoing = GameObject.FindWithTag("Timer").GetComponent<timecode>();
        dropchance = Random.Range(1, 75);
        graphic = transform.Find("graphic").gameObject;
        sRenderer = graphic.GetComponent<SpriteRenderer>();
        anim = graphic.GetComponent<Animator>();

        sfxman = FindObjectOfType<sfxmanager>();
        target = GameObject.FindWithTag("Player").transform;
        playertgt = FindObjectOfType<playerstats>();
        myTransform = transform;
        hp = maxhp;
        timer = 10;
    }

    //the function when the enemy's hitbox touches the player's attack hitbox
    public void HurtEnemy(int bulldmg)
    {
        if (delay <= 0f)
        {

            hp -= bulldmg;
            delay = maxdelay;
            Instantiate(hurtfx, transform.position, transform.rotation);
            sfxman.enemyHurt.Play();
        }


    }

    // Update is called once per frame
    void Update()
    {

        //  Vector3 targetDir = target.position - transform.position;

        // float step = speed * Time.deltaTime;

        //  Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        //  transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        //  Debug.DrawRay(transform.position, newDir, Color.red);
        //flashing red when hurt, the only thing we need now is some particle effects to get that statisfication of a hit
        timer -= Time.deltaTime;


        if (timer <= 0)
        {
            Die();
        }
        timelimit = levelgoing.GetComponent<timecode>().timer;
        if (timelimit <= 0.2)
        {
            Die();
        }

        Vector3 direction = target.position - transform.position;
        direction.Normalize();

        angle = Mathf.Atan2(direction.x, direction.y) * -Mathf.Rad2Deg;

        if (angle <= -91 && angle >= -180 || angle >= 91 && angle <= 180)
        {
            //down
            transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
        }
        if (angle >= -89 && angle <= 0 || angle <= 89 && angle >= 0)
        {
            //up
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }
        if (angle >= 0 && angle <= 179)
        {
            //left
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (angle <= 0 && angle >= -179)
        {
            //right
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
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
            expadd = Random.Range(4, 7);
            playertgt.Addexp(expadd);


            if (dropchance == 69)
            {
                Instantiate(gernade, transform.position, transform.rotation);
                Die();
            } else
            {
                Die();
            }
            
        }


    }

    public void Die()
    {
        enemyspawn.enemycount--;
        Destroy(gameObject);

    }
}
