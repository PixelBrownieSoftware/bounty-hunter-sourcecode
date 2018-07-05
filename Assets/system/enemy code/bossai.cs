using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bossai : MonoBehaviour {

    public enum Actions { moving, attacking, shooting }
    public Actions bossaction;

    private bool hurt;
    private float maxdelay = 0.2f;
    private float delay;
    public int hp;
    public int maxhp = 300;
    public enemydamage user;
    public playerstats playertgt;

    public GameObject explsion;
    public GameObject bullet;
    private GameObject graphic;
    public GameObject hurtfx;

    private sfxmanager sfxman;

    public Text hpdisplayer;
    public Image gui;
    public Transform target;
    public float speed;
    private Transform myTransform;
    public float angle;
    private timecode levelgoing;

    public float aidelay;
    public bool aiactive;

    private SpriteRenderer fRenderer;

    void Awake()
    {
        sfxman = FindObjectOfType<sfxmanager>();
        graphic = transform.Find("graphic").gameObject;
        fRenderer = graphic.GetComponent<SpriteRenderer>();
        target = GameObject.FindWithTag("Player").transform;
        playertgt = FindObjectOfType<playerstats>();
        myTransform = transform;
        hp = maxhp;
        levelgoing = GameObject.FindWithTag("Timer").GetComponent<timecode>();
        bossaction = Actions.attacking;
    }
    
    void Update () {
        if (levelgoing.level == 5) {
            if (aiactive == false)
            {
                bossaction = Actions.moving;
                aidelay = Random.Range(5f, 13f);
                aiactive = true;
            }

            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            angle = Mathf.Atan2(direction.x, direction.y) * -Mathf.Rad2Deg;

            if (aidelay > 0.0f)
            {
                //the timer goes down 
                aidelay -= Time.deltaTime;

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

            switch (bossaction)
            {
                case Actions.moving:

                    if (aidelay > 0.0f)
                    {
                        float step = speed * Time.deltaTime;
                        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
                    }
                    else
                    {
                        if (aidelay < 0.0f)
                            Instantiate(explsion, transform.position, transform.rotation);
                        Instantiate(explsion, transform.position, transform.rotation);
                        bossaction = Actions.attacking;
                        aidelay = Random.Range(3f, 6f);
                    }
                    break;

                case Actions.attacking:

                    {
                        if (aidelay >= 0.0f)
                            bossaction = Actions.shooting;
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

            if (hp <= 0)
            {
                GameObject.Find("fx").GetComponent<fade>().StartCoroutine("whitein");
                Die();
            }
        }
    }
        

    public void HurtEnemy(int bulldmg)
    {
        if (delay <= 0f)
        {
            Instantiate(hurtfx, transform.position, transform.rotation);
            sfxman.enemyHurt.Play();
            sfxman.freshizaHurt.Play();
            hp -= bulldmg;
            delay = maxdelay;
        }
    }

    void OnGUI()
    {
        if (levelgoing.level == 5)
        {
            hpdisplayer.text = "Boss HP:" + hp;
            hpdisplayer.enabled = true;
            gui.enabled = true;
        }
        else
        {
            hpdisplayer.enabled = false;
            gui.enabled = false;

        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
