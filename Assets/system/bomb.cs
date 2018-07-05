using UnityEngine;
using System.Collections;

public class bomb : playerbulletcode {

    public float timer;
    public GameObject explsion;
    

    void Start () {
        Instantiate(explsion, transform.position, transform.rotation);
        bulletsounds = transform.GetComponent<AudioSource>();
        maxspeed = 1.7f;
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<playerstats>();
        bulldmg = 4;
    }

    void OnTriggerStay2D(Collider2D attktrigger)
    {
        if (attktrigger.gameObject.tag == "Enemy")
        {
            //FindGameObjectWithTag("Enemy");

            attktrigger.SendMessageUpwards("HurtEnemy", bulldmg);
        }
    }
    
    void Update () {

    }
}
