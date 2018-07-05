using UnityEngine;
using System.Collections;

public class destroyself : MonoBehaviour {

    /* 
* DEV'S COMMENTS 10/11/2017 - Self expalinitory.
*/

    public float timer;

    void Update () {
        timer -= Time.deltaTime;


            if(timer <= 0)
        {
            Destroy(gameObject);
        }
	}
}
