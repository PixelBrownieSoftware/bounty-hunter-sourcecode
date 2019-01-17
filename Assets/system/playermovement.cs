/* 
         * DEV'S COMMENTS 10/11/2017 - I honestly don't think this is a good way of handling movement, in Bounty Hunter 2
         * I have unity's built-in function "vspeed = Input.GetAxisRaw("Vertical")"
         */

using UnityEngine;
using System.Collections;

public class playermovement : MonoBehaviour {
    
    public float speed;
    public float hspeed;
    public float vspeed;
    private int dir;

    public Transform firept;
    public bool attacking;
    
    void Update()
    {
        if (attacking == false)
        {
            if (Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                hspeed = -0.85f;         
                transform.position += new Vector3(hspeed, 0, 0) * Time.deltaTime;
            }

            if (Input.GetAxisRaw("Horizontal") > 0.5f)
            {
                hspeed = 0.85f;
                transform.position += new Vector3(hspeed, 0, 0) * Time.deltaTime;
            }

            if (Input.GetAxisRaw("Vertical") < -0.5f)
            {
                vspeed = -0.85f;
                transform.position += new Vector3(0, vspeed, 0) * Time.deltaTime;
            }

            if (Input.GetAxisRaw("Vertical") > 0.5f)
            {
                vspeed = 0.85f;
                transform.position += new Vector3(0, vspeed, 0) * Time.deltaTime;
            }
        }
    }

}

