using UnityEngine;
using System.Collections;

public class playerbulletcode : MonoBehaviour
{


    public playerstats stats;
    public int bulldmg;
    public Collider2D attktrigger;
    public float maxspeed;

    public AudioSource bulletsounds;
    public AudioClip hitimpact;


    void Start()
    {
        bulletsounds = transform.GetComponent<AudioSource>();
        maxspeed = 1.7f;
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<playerstats>();
        bulldmg = stats.GetComponent<playerstats>().hit;
    }

    void OnTriggerStay2D(Collider2D attktrigger)
    {
        if (attktrigger.gameObject.tag == "Enemy")
        {
            //FindGameObjectWithTag("Enemy");

            attktrigger.SendMessageUpwards("HurtEnemy",bulldmg);
            

            if (stats.level <= 3) {
                Destroy(gameObject);
            }
         }
    }
    

    // Update is called once per frame
    void Update () {
        maxspeed = stats.GetComponent<playerstats>().bullespeed;

        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, maxspeed * Time.deltaTime, 0);

        pos += transform.rotation * velocity;

        transform.position = pos;
    }
}
