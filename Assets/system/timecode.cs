using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timecode : MonoBehaviour {

    /* 
    * DEV'S COMMENTS 10/11/2017 - This class is essentaly the "heart" of the game as it loads levels, sets the timer and determines the game over.
    * It was originaly mean to be just a timer (hence the name "timecode") but it essentaly became a blob as does more than just time things. Clear signs of
    * noobiness can be seen with the vast amount of "public GameObject"s seen below. I didn't really know much about arrays at the time.
    * If that wasn't bad enough, we have a static integer being incremented by the spawners; at the time I didn't really know a better way to do this.
    * 
    * Obviously now I know that it's a better idea to keep track of the enemies by having an array or a list of enemies and using unity's "GameObject.FindGameObjectsWithTag"
    * function to find all the gameobjects with the "Enemy" tag.
    */

    public float timer;
    public playerstats health;
    public static int enemycount;
    public GameObject player;
    public GameObject enemyspawner;
    public GameObject enemyspawner2;
    public GameObject enemyspawner3;
    public GameObject enemyspawner4;
    public GameObject enemyspawner5;
    public GameObject enemyspawner6;
    public GameObject ghostie;

    public Image timergui;
    private bgmanger sfxman;

    public Text timelimit;
    public Text debug;
    public int level;


    void Start()
    {
        sfxman = FindObjectOfType<bgmanger>();
        player = GameObject.FindGameObjectWithTag("Player");
        health = GameObject.FindWithTag("Player").GetComponent<playerstats>();
        sfxman.level1.Play();
        player.transform.position = new Vector3(3, -5.4f, 1);
        enemyspawn.enemycount = 0;
        Instantiate(enemyspawner, new Vector3(0, 0.6f, 1), Quaternion.identity);
        Instantiate(enemyspawner, new Vector3(3, -2.3f, 1), Quaternion.identity);
        Instantiate(enemyspawner, new Vector3(0.1f, -5.5f, 1), Quaternion.identity);
        Instantiate(enemyspawner, new Vector3(5.5f, -4, 1), Quaternion.identity);
        Instantiate(enemyspawner, new Vector3(0.5f, -2.9f, 1), Quaternion.identity);
        Instantiate(enemyspawner, new Vector3(5.4f, 0.6f, 1), Quaternion.identity);
    }

    void OnGUI()
    {
        if (level <= 4) { timelimit.text = "Time: " + timer.ToString("0");
            timergui.enabled = true;
            // debug.text = "Radar " + enemyspawn.enemycount;
            debug.text = "";
        }
        else { timelimit.text = "";
            timergui.enabled = false;
        }

        //GUI.DrawTexture(new Rect(543, 35, 70, 40), bar);
    }
    
    void Update() {

        if (timer >= 0 && (level <= 4)) { timer = timer - Time.smoothDeltaTime; }

        if (health.GetComponent<playerstats>().hp <= 0)
        {
            SceneManager.LoadScene("mainmenu");
            // health.GetComponent<playerstats>().Dead();
        }
        if (timer <= 0 ) {
            GameObject.Find("fx").GetComponent<fade>().StartCoroutine("whiteout");
            level++;
            Positioning();
            timer = 110;
        }
    }

    /* 
    * DEV'S COMMENTS 10/11/2017 - This was basicaly the thing that puts postions of enemy spawners and the players position on that level.
    * I'm quite aware that there are better methods of doing this i.e. creating stucts that hold spawner data.
    */

    void Positioning()
    {
        if (level == 2)
        {
            sfxman.level1.Stop();
            sfxman.level2.Play();
            player.transform.position = new Vector3(12, -1, 0);
            
            Instantiate(enemyspawner, new Vector3(12.7f, -3.8f, 1), Quaternion.identity);
            Instantiate(enemyspawner3, new Vector3(17, -8.4f, 1), Quaternion.identity);
            Instantiate(enemyspawner, new Vector3(19.7f, -6f, 1), Quaternion.identity);
            Instantiate(enemyspawner3, new Vector3(21.6f, -3.7f, 1), Quaternion.identity);
            Instantiate(enemyspawner, new Vector3(14.3f, -6f, 1), Quaternion.identity);
            Instantiate(enemyspawner, new Vector3(21.7f, -3.9f, 1), Quaternion.identity);
        }

        if (level == 3)
        {
            sfxman.level2.Stop();
            sfxman.level3.Play();
            player.transform.position = new Vector3(38.5f,-4, 0);

            Instantiate(ghostie, new Vector3(45, -7f, 1), Quaternion.identity);
            Instantiate(ghostie, new Vector3(19, -7f, 1), Quaternion.identity);
            Instantiate(enemyspawner2, new Vector3(30, -7f, 1), Quaternion.identity);
            Instantiate(enemyspawner4, new Vector3(36, -1.7f, 1), Quaternion.identity);
            Instantiate(enemyspawner2, new Vector3(39.5f, -5.5f, 1), Quaternion.identity);
            Instantiate(enemyspawner4, new Vector3(30, 3.2f, 1), Quaternion.identity);
            Instantiate(enemyspawner2, new Vector3(33, 1.6f, 1), Quaternion.identity);

        }
        if (level == 4)
        {
            sfxman.level3.Stop();
            sfxman.level4.Play();
            player.transform.position = new Vector3(53.5f, -6, 0);

            Instantiate(ghostie, new Vector3(49, -7f, 1), Quaternion.identity);
            Instantiate(ghostie, new Vector3(89, -7f, 1), Quaternion.identity);
            Instantiate(enemyspawner5, new Vector3(51.6f, 3.2f, 1), Quaternion.identity);
            Instantiate(enemyspawner6, new Vector3(56.4f, 3.7f, 1), Quaternion.identity);
            Instantiate(enemyspawner5, new Vector3(53.4f, 2.8f, 1), Quaternion.identity);
            Instantiate(enemyspawner6, new Vector3(58.6f, 2.4f, 1), Quaternion.identity);
            Instantiate(enemyspawner5, new Vector3(60.5f, -5.5f, 1), Quaternion.identity);
            Instantiate(enemyspawner5, new Vector3(51.6f, -7.5f, 1), Quaternion.identity);
            Instantiate(enemyspawner5, new Vector3(54.4f, -7.5f, 1), Quaternion.identity);
        }
        if (level == 5)
        {
            sfxman.level4.Stop();
            sfxman.finalboss.Play();
            player.transform.position = new Vector3(71.5f, -3.5f, 0);

        }
    }
}
