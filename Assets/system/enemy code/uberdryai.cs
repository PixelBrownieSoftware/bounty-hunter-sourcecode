using UnityEngine;
using System.Collections;

public class uberdryai : MonoBehaviour {

    public enum Actions { moving, reatreating, shooting }
    public Actions bossaction;

    public float aidelay;
    public bool aiactive;


    // Use this for initialization
    private bool hurt;
    private float maxdelay = 0.2f;
    public float atkdelay;
    private float delay;
    public int hp;
    public int expadd;
    public int maxhp;
    public enemydamage user;
    public playerstats playertgt;

    private timecode levelgoing;
    private float timelimit;

    public GameObject enemydrop;
    public GameObject explsion;
    public GameObject hurtfx;
    private sfxmanager sfxman;

    private SpriteRenderer uRenderer;
    public GameObject graphic;
    public GameObject uncon;

    Animator anim;

    public float angle;

    public Transform target;
    public Transform playerbullet;
    public float speed;
    private Transform myTransform;

    // Use this for initialization
    void Start()
    {
        graphic = transform.Find("graphic").gameObject;
        uRenderer = graphic.GetComponent<SpriteRenderer>();
        anim = graphic.GetComponent<Animator>();
        levelgoing = GameObject.FindWithTag("Timer").GetComponent<timecode>();

        uncon = null;

        sfxman = FindObjectOfType<sfxmanager>();
        target = GameObject.FindWithTag("Player").transform;
        
        playertgt = FindObjectOfType<playerstats>();
        myTransform = transform;
        hp = maxhp;
        bossaction = Actions.moving;


    }

    //this points the hitbox in the direction of the attack as well as activating it.

    //the function when the enemy's hitbox touches the player's attack hitbox
    public void HurtEnemy(int bulldmg)
    {
        if (delay <= 0f)
        {
            hp -= bulldmg;
            delay = maxdelay;
            aidelay = 4.3f;
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
        if (timelimit <= 0.2)
        {
            Die();
        }

        if (aidelay <= 0) { bossaction = Actions.moving; }
            /* playerbullet = GameObject.Find("playerbullet").transform;

             if (Vector3.Distance(transform.position, playerbullet.position) >= 1.2f)
             {
                 bossaction = Actions.reatreating;
             }
             else { bossaction = Actions.moving; } */

            delay -= Time.deltaTime;
            atkdelay -= Time.deltaTime;
            aidelay -= Time.deltaTime;

            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            angle = Mathf.Atan2(direction.x, direction.y) * -Mathf.Rad2Deg;


            switch (bossaction)
            {
                case Actions.moving:


                    if (Vector3.Distance(transform.position, target.position) >= 0.97f)
                    {
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
                }
                    break;

                case Actions.reatreating:
                    if (Vector3.Distance(transform.position, target.position) >= 0.47f)
                    {

                        if (angle <= -91 && angle >= -180 || angle >= 91 && angle <= 180)
                        {
                            //down
                            anim.SetFloat("inp_x", 0); anim.SetFloat("inp_y", 1);
                            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
                        }
                        if (angle >= -89 && angle <= 0 || angle <= 89 && angle >= 0)
                        {
                            //up
                            anim.SetFloat("inp_x", 0); anim.SetFloat("inp_y", -1);
                            transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
                        }
                        if (angle >= 0 && angle <= 179)
                        {
                            //left
                            anim.SetFloat("inp_y", 0); anim.SetFloat("inp_x", 1);
                            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
                        }
                        if (angle <= 0 && angle >= -179)
                        {
                            //right
                            anim.SetFloat("inp_y", 0); anim.SetFloat("inp_x", -1);
                            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;

                        }
                    }
                    break;

                case Actions.shooting:


                    if (aidelay > 0.0f)
                    {


                    }
                    else if (aidelay < 0.0f)
                    {

                        aiactive = false;
                    }
                    break;
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

        //temp = Vector3.Distance(transform.position, target.position);

        //kicks the bucket if hp = 0
        if (hp <= 0)
        {
            Instantiate(explsion, transform.position, transform.rotation);
            expadd = Random.Range(25, 35);
            playertgt.Addexp(expadd);
            
            Die();
        }


    }

    public void Die()
    {
        enemyspawn.enemycount--;
        Destroy(gameObject);

    }
}
