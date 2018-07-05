using UnityEngine;
using System.Collections;

public class healingheart : MonoBehaviour {
    
    public int healamount;
    public Collider2D attktrigger;
    public float maxspeed;
    
    void OnTriggerStay2D(Collider2D attktrigger)
    {
        if (attktrigger.gameObject.tag == "Player")
        {
            healamount = Random.Range(2, 3);
            //FindGameObjectWithTag("Enemy");
            attktrigger.SendMessageUpwards("HealPlayer", healamount);

            Destroy(gameObject);

        }
    }
}
