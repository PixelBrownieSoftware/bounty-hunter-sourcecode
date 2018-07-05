using UnityEngine;
using System.Collections;

public class playerdamage : MonoBehaviour {

    public GameObject bullet;
    public GameObject bomb;
    public playermovement atk;
    private sfxmanager sfxman;
    public playerstats bombam;

    public int bombs;

    float cooldown;
    public float timerstrt = 0.2f;
    

    void Start() {
        sfxman = FindObjectOfType<sfxmanager>();
        
    }

    /* 
        * DEV'S COMMENTS 10/11/2017 - This class is basicaly the class that instantiates the bullets, it rotates depending on what keys the players press
        * ; in retrospect this class was kinda pointless because I could have just made a float variable that represents an angle converted from a vector 
        * (that has the inputgetaxis numbers), but I was a noob at C#/Unity back then.
        */

    void Update()
    {

        if (Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }

        if (Input.GetAxisRaw("Horizontal") > 0.5f)
        {
            transform.eulerAngles = new Vector3(0, 0, 270);
        }

        if (Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        cooldown -= Time.deltaTime;
        bombs = bombam.GetComponent<playerstats>().bombcount;

        /* 
    * DEV'S COMMENTS 10/11/2017 - I actually implemented this feature in around early december or late november 2016, largely because of how I hated having to be
    * surrounded by a group of enemies and mash the Z button in vain. Hence I implemented the bomb which damages surrounding enemies constantly, it's a good weapon to use
    * whenever you are in a pickle.
    */
        if (Input.GetButtonDown("decline") && cooldown <= 0 && bombs > 0)
        {
            cooldown = 1.2f;
            bombam.GetComponent<playerstats>().bombcount--;
            Instantiate(bomb, transform.position, transform.rotation);
        }

        if (Input.GetButtonDown("interact") && cooldown <= 0)
        {
            atk.GetComponent<playermovement>().attacking = true;
            sfxman.shootSfx.Play();
            cooldown = timerstrt;

            Instantiate(bullet, transform.position, transform.rotation);
        } else if (cooldown <= 0)
        {
            atk.GetComponent<playermovement>().attacking = false;

        }
    }

}
