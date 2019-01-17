using UnityEngine;
using System.Collections;

public class POUCH : MonoBehaviour {

    /* 
         * DEV'S COMMENTS 10/11/2017 - This was only used to play the animated cutscenes"
         */

    public float timer;
    public bool timerOn;
    public float delayBetweenScenes;
    public int scene;

    // POUCH is an acryonm for Prowniebrowniesoft's Outstandingly Ultimate Cutscene Handler

	public void Update () 
	{
        	if (timerOn)
        	{
            		timer -= Time.deltaTime;
        	}
        	if (timer <= 0.0 && timerOn)
        	{
            		scene++;
            		timerOn = false;
        	}
        }

}
