using UnityEngine;
using System.Collections;

public class ghostieai : MonoBehaviour {

    private bool hurt;
    private float maxdelay = 0.2f;
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
    public GameObject gernade;
    private sfxmanager sfxman;
    private timecode levelgoing;
    private int timelimit;
    private float angle;

    public Transform target;
    private float speed;
    private Transform myTransform;


    void Awake()
    {
        dropchance = 2;
        levelgoing = GameObject.FindWithTag("Timer").GetComponent<timecode>();
        speed = 1;
        target = GameObject.FindWithTag("Player").transform;
        playertgt = FindObjectOfType<playerstats>();
        myTransform = transform;
        hp = maxhp;
        sfxman = FindObjectOfType<sfxmanager>();
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
            Instantiate(hurtfx, transform.position, transform.rotation);
            hp -= bulldmg;
            delay = maxdelay;
            sfxman.enemyHurt.Play();
            sfxman.ghostieHurt.Play();
            transform.position = new Vector3(Random.Range(1, 18), Random.Range(1,3), 1);
        }


    }
    
    void Update()
    {
         timelimit = levelgoing.GetComponent<timecode>().level;
        if (timelimit == 5)
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
        //flashing red when hurt, the only thing we need now is some particle effects to get that statisfication of a hit
        if (delay >= 0)
        {
            delay -= Time.deltaTime;
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.color = new Color(11f, 0f, 0.5f, 1f); // Set to red
        }
        else
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.color = new Color(1.5f, 1.5f, 1.5f, 1.5f);
        }



        //kicks the bucket if hp = 0
        if (hp <= 0)
        {
            Instantiate(explsion, transform.position, transform.rotation);
            expadd = Random.Range(43, 45);
            playertgt.Addexp(expadd);
            Instantiate(gernade, transform.position, transform.rotation);

            if (dropchance == 2)
            {
                Instantiate(enemydrop, transform.position, transform.rotation);
            }
            Die();
        }

    }

    public void Die()
    {
        Destroy(gameObject);

    }

}
