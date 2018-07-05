using UnityEngine;
using System.Collections;

public class slimeattack : enemydamage {

    public float atkdelay;
    
	// Use this for initialization
	void Start () {
        atkcooldown = 1.4f;
        target = GameObject.FindWithTag("Player").transform;
    }

    void OnTriggerStay2D(Collider2D attktrigger) 
    {
        if (attktrigger.gameObject.tag == "Player" && (atkdelay <= 0))
        {
            atkdelay = atkcooldown;
            //FindGameObjectWithTag("Enemy");
        }
    }

    // Update is called once per frame
    void Update () {
        atkdelay = atkdelay* Time.deltaTime;

        if (atkdelay >= 0) {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, 0);
        }
    }
}
