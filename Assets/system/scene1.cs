using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class scene1 : POUCH {

    Animator anim;

    void Start () {
        anim = GetComponent<Animator>();
        cutscene();

    }
	
    void cutscene() {
        if (scene == 1)
        {
            timerOn = true;
            timer = 1.6f;
        }
        if (scene == 2)
        {
            timerOn = true;
            timer = 1.2f;
        }
        if (scene == 3)
        {
            timerOn = true;
            timer = 1f;
        }
        if (scene == 4)
        {
            timerOn = true;
            timer = 0.74f;
        }
        if (scene == 5)
        {
            timerOn = true;
            timer = 0.63f;
        }
        if (scene == 6)
        {
            timerOn = true;
            timer = 1.6f;
        }
        if (scene == 7)
        {
            timerOn = true;
            timer = 1f;
        }

    }

    void FixedUpdate()
    {
        if (timer <= 0.0 && !timerOn && scene != 8)
        {
            anim.SetInteger("sceneNum", scene);
            if (delayBetweenScenes <= 0)
            {
                cutscene();
            }

        }else if (scene >6) {
            SceneManager.LoadScene("mainmenu");
        }

        
    }


	// Update is called once per frame
}
