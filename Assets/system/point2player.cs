using UnityEngine;
using System.Collections;

public class point2player : enemydamage
{

    /* 
    * DEV'S COMMENTS 10/11/2017 - Like the playerdamage class, this is also pointless. Nuff said...
    */

    public float rotspeed;
    public float angle;

	void Start () {
        target = GameObject.FindWithTag("Player").transform;
    }
	

	void Update () {

        Vector3 direction = target.position - transform.position;
        direction.Normalize();

        angle = Mathf.Atan2(direction.x, direction.y) * -Mathf.Rad2Deg;

        Quaternion desiredRot = Quaternion.Euler(0, 0, angle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotspeed * Time.deltaTime);
    }
}
