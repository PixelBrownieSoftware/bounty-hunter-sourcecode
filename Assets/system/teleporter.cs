using UnityEngine;
using System.Collections;

public class teleporter : MonoBehaviour {

    public float telx;
    public float tely;
    public Collider2D attktrigger;
    public GameObject player;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
	
    void OnTriggerEnter2D(Collider2D attktrigger)
    {
        if (attktrigger.gameObject.tag == "Player")
        {
            player.transform.position = new Vector3(telx, tely, 1);
        }
       
    }

    
}
