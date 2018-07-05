using UnityEngine;
using System.Collections;

public class collisiondetection : MonoBehaviour {

    /* 
* DEV'S COMMENTS 10/11/2017 - This was my attemtps at collisin detection, I've struggled with this for years and I still do.
* I eventually decided to just use unity's rigidbody to do the work for me :P.
*/

    private playermovement collision;
    public GameObject player;

    // Use this for initialization
    void Start () {
        

    }
    

    // Update is called once per frame
    void Update () {
	    if (player.GetComponent<playermovement>()) {


        }
	}
}
