using UnityEngine;
using System.Collections;

public class bombitem : MonoBehaviour {

    public int healamount;
    public Collider2D attktrigger;
    public float maxspeed;
    public playerstats bombam;

    void Start()
    {
        bombam = GameObject.FindWithTag("Player").GetComponent<playerstats>();
    }

    // Use this for initialization
    void OnTriggerStay2D(Collider2D attktrigger)
    {
        if (attktrigger.gameObject.tag == "Player")
        {
            healamount = Random.Range(2, 3);
            //FindGameObjectWithTag("Enemy");
            bombam.GetComponent<playerstats>().bombcount++;

            Destroy(gameObject);

        }
    }
}
