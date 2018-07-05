using UnityEngine;
using System.Collections;

public class freshizashoot : enemydamage {

    public bossai com;
    public GameObject user;
    public float rotspeed;
    public float angle;
    public float angle2;
    private sfxmanager sfxman;

    private bool ataking; 

    // Use this for initialization
    void Start()
    {
        sfxman = FindObjectOfType<sfxmanager>();
        target = GameObject.FindWithTag("Player").transform;
    //    ataking = com.GetComponent<bossai>();
        com = GameObject.Find("Freshiza").GetComponent<bossai>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();


        angle = Mathf.Atan2(direction.x, direction.y) * -Mathf.Rad2Deg;


        Quaternion desiredRotdir = Quaternion.Euler(0, 0, angle);

        Quaternion desiredRot = Quaternion.Euler(0, 0, angle + 100);
        Quaternion desiredRot2 = Quaternion.Euler(0, 0, angle+ 140);
        Quaternion desiredRot3 = Quaternion.Euler(0, 0, angle + 170);
        Quaternion desiredRot4 = Quaternion.Euler(0, 0, angle + 200);
        Quaternion desiredRot5 = Quaternion.Euler(0, 0, angle -100);
        Quaternion desiredRot6 = Quaternion.Euler(0, 0, angle - 140);
        Quaternion desiredRot7 = Quaternion.Euler(0, 0, angle - 170);
        Quaternion desiredRot8 = Quaternion.Euler(0, 0, angle - 200);
        Quaternion desiredRot9 = Quaternion.Euler(0, 0, angle + 20);
        Quaternion desiredRot10 = Quaternion.Euler(0, 0, angle + 60);
        Quaternion desiredRot11 = Quaternion.Euler(0, 0, angle + 0);

        attktime -= Time.deltaTime;




        if (Vector3.Distance(target.position, transform.position) < 1.3 && attktime <= 0 && (com.bossaction == bossai.Actions.moving))
        {

            bullet.GetComponent<enemybullet>().bulldmg = atk;
            bullet.GetComponent<enemybullet>().maxspeed = 2f;

            Instantiate(bullet, transform.position, desiredRotdir);
            attktime = atkcooldown;
        }

        if ((com.bossaction == bossai.Actions.moving) && (com.aidelay == 0.3f))
        {
            sfxman.freshizaLaugh.Play();
        }

            if ((com.bossaction == bossai.Actions.moving )&& (com.aidelay < 0.1f))
        {

            bullet.GetComponent<enemybullet>().bulldmg = atk;
            bullet.GetComponent<enemybullet>().maxspeed = 1.9f;

            Instantiate(bullet, transform.position, desiredRot);
            Instantiate(bullet, transform.position, desiredRot2);
            Instantiate(bullet, transform.position, desiredRot3);
            Instantiate(bullet, transform.position, desiredRot4);
            Instantiate(bullet, transform.position, desiredRot5);
            Instantiate(bullet, transform.position, desiredRot6);
            Instantiate(bullet, transform.position, desiredRot7);
            Instantiate(bullet, transform.position, desiredRot8);
            Instantiate(bullet, transform.position, desiredRot9);
            Instantiate(bullet, transform.position, desiredRot10);
            Instantiate(bullet, transform.position, desiredRot11);
            attktime = atkcooldown;
        }
    }
}
