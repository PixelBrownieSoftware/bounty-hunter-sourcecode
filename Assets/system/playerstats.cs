using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerstats : MonoBehaviour {

    /* 
     * * DEV'S COMMENTS 10/11/2017 - Funnily enough the player has 3 classes to it, One for stats (this one), one for movement and one for shooting"
        */

    public int hp;
    public int maxhp = 100;
    private float maxdelay = 0.2f;
    private float delay;
    public int bombcount;

    public Text hpdisplayer;
    public Text lvl;
    public Text experience;
    public Text bombs;

    private sfxmanager sfxman;

    public Texture barend;
    public GameObject graphic;

    public int[] levelreq;
    public int level;

    public int exp;

    public float[] bulletspeedlvl;
    public int[] hitlvl;

    public int hit;
    public float bullespeed;

    

    void Start () {
        graphic = transform.Find("graphic").gameObject;
        hp = maxhp;
        sfxman = FindObjectOfType<sfxmanager>();

        hit = hitlvl[1];
       bullespeed = bulletspeedlvl[1];
	}

    public void HurtPlayer(int atk) {
       
        if (delay <= 0f)
        {
            hp -= atk;
            delay = maxdelay;
            sfxman.playerHurt.Play();
        }
    }

    public void HealPlayer(int heal)
    {

        hp += heal;
    }

    public void Dead()
    {
        Destroy(gameObject);
    }



	void Update () {

        if(hp > maxhp)
        {
            hp = maxhp;

        }

        if(exp >= levelreq[level])
        {
                LevelUp();
        }

        if (delay >= 0)
        {
            delay -= Time.deltaTime;
            SpriteRenderer renderer = graphic.GetComponent<SpriteRenderer>();
            renderer.color = new Color(11f, 0f, 0.5f, 1f); // Set to red
        }
        else
        {
            SpriteRenderer renderer = graphic.GetComponent<SpriteRenderer>();
            renderer.color = new Color(1.5f, 1.5f, 1.5f, 1.5f);
        }
    }



    public void Addexp(int expadd)
    {
        if (level <= 3)
        {
            exp += expadd;

        }
    }

    public void LevelUp()
    {
        if (level <= 3)
        {
            level++;
            hit = hitlvl[level];
            bullespeed = bulletspeedlvl[level];
        }
    }
    

    void OnGUI()
    {
        hpdisplayer.text = "Peast HP:" + hp;
        bombs.text = "Bombs:" + bombcount;

        if (level <= 3)
        {
            lvl.text = "Level:" + level;
            experience.text = "Exp " + exp + "/" + levelreq[level];
        }
        else
        {
            exp = 0;
            experience.text = "Max";
            lvl.text = "Level: Max";
        }
        

        //GUI.DrawTexture(new Rect(543, 35, 70, 40), bar);
    }

}
