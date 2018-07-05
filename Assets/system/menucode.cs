using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menucode : MonoBehaviour {


    public int menuchoice;
    public int highlight;

    public Texture2D infomenu;


    public bool infoon;
    // Use this for initialization
    void Start () {
	
	}





    // Update is called once per frame
    void Update()
    {
        /*    

        menuchoice = Mathf.Clamp(menuchoice, 1, 2);

        if (menuchoice == 1)
        {
            if (Input.GetButtonDown("interact"))
            {
                infoon = true;
            }

            if (Input.GetButtonDown("decline"))
            {
                infoon = false;
            }

            if (menuchoice == highlight)
            {
                SpriteRenderer renderer = GetComponent<SpriteRenderer>();
                renderer.color = new Color(7f, 0.4f, 0.3f,6f);
            }
            else
            {
                SpriteRenderer renderer = GetComponent<SpriteRenderer>();
                renderer.color = new Color(1.5f, 1.5f, 1.5f, 1.5f);
            }
        }*/
        if (menuchoice == 1)
        {

            if (Input.GetButtonDown("interact") && infoon == false)
            {
                SceneManager.LoadScene("testgamr");
            }


         /*   if (menuchoice == highlight)
            {
                SpriteRenderer renderer = GetComponent<SpriteRenderer>();
               // renderer.color = new Color(7f,0.4f, 0.3f, 6f); // Set to red
            }
            else
            {
                SpriteRenderer renderer = GetComponent<SpriteRenderer>();
               // renderer.color = new Color(1.5f, 1.5f, 1.5f, 1.5f);
            }
            */
        }
    }

    public void OnGUI()
    {
        if (infoon == true) { GUI.Box(new Rect(290, 250, 1999, 1999), infomenu, ""); } else { }

    }


}
