﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//This is meant to be the renderer to the main character
//

public class graphic : MonoBehaviour {
    Animator anim;

    void Start() {

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        if ((Input.GetAxisRaw("Horizontal") != 0f) || (Input.GetAxisRaw("Vertical") != 0f))
        {
            anim.SetBool("iswalking", true);
            anim.SetFloat("inp_x", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("inp_y", Input.GetAxisRaw("Vertical"));

        }
        else { anim.SetBool("iswalking", false); }


        


        if (Input.GetButtonDown("interact"))
        {
           // anim.SetBool("ishiting", true);
        }
        else
        {
           // anim.SetBool("ishiting", false);
        }
    }


}
