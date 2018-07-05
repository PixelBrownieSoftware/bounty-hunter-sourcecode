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

        /* if (hspeed != 0 || vspeed != 0)
         {
             anim.SetBool("iswalking", true);
             anim.SetFloat("inp_x", hspeed);
             anim.SetFloat("inp_y", vspeed);

         }
         else {
             anim.SetBool("iswalking", false);
         }

         if (Input.GetButtonDown("interact"))
         {
             anim.SetBool("ishiting", true);
         }
         else
         {
             anim.SetBool("ishiting", false);
         }
         */



        //moving without rigidbody
        /* 
         * DEV'S COMMENTS 10/11/2017 - I honestly don't think this is a good way of handling movement, in Bounty Hunter 2
         * I have unity's built-in function "vspeed = Input.GetAxisRaw("Vertical")"
         */

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

        


        // if (Input.GetAxisRaw("Vertical") < 0.5f || Input.GetAxisRaw("Vertical") > 0.5f)
        //  {
        //     transform.Translate(new Vector3(0f ,Input.GetAxisRaw("Vertical") * hspeed * Time.deltaTime, 0f));
        //  }


    }


}

