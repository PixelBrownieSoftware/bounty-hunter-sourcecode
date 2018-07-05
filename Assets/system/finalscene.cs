using UnityEngine;
using System.Collections;

public class finalscene : POUCH
{

    // Use this for initialization
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        cutscene();

    }

    void cutscene()
    {
        if (scene == 1)
        {
            timerOn = true;
            timer = 0.8f;
        }
        if (scene == 2)
        {
            timerOn = true;
            timer = 2f;
        }
        if (scene == 3)
        {
            timerOn = true;
            timer = 1f;
        }
       

    }

    void FixedUpdate()
    {
        if (timer <= 0.0 && !timerOn && scene != 4)
        {
            anim.SetInteger("sceneNum", scene);
            if (delayBetweenScenes <= 0)
            {
                cutscene();
            }
        }
    }
}