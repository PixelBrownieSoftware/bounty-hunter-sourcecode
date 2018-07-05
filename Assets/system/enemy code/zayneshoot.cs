using UnityEngine;
using System.Collections;

public class zayneshoot : enemydamage {

    
    
    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {

        attktime -= Time.deltaTime;

        if (Vector3.Distance(target.position, transform.position) < 1.3 && attktime <= 0)
        {

            bullet.GetComponent<enemybullet>().bulldmg = atk;
            bullet.GetComponent<enemybullet>().maxspeed = 1.3f;

            Instantiate(bullet, transform.position, transform.rotation);
            attktime = atkcooldown;
        } 
    }
}
