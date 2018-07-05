using UnityEngine;
using System.Collections;

public class enemydamage : MonoBehaviour
{

    public Collider2D attktrigger;
    public int atk;
    public float atkcooldown = 0.6f;
    public float attktime;
    public bool atking = false;
    public Transform target;
    public GameObject bullet;
    public bool shooting;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void OnTriggerStay2D(Collider2D attktrigger)
    {
        if ((attktrigger.gameObject.tag == "Player") && atking == false && attktime <= 0)
        {
            attktrigger.GetComponent<playerstats>().HurtPlayer(atk);
            // attktrigger.enabled = false;#
            attktime = atkcooldown;
            atking = true;
        }
    }

    void Update()
    {
        if (atking)
        {
            if (attktime > 0.0f)
            {
                //the timer goes down 
                attktime -= Time.deltaTime;
            }
            else
            {
                //once the timer has stopped
                atking = false;
            }
        }
    }

}


