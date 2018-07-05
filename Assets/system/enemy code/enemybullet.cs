using UnityEngine;
using System.Collections;

public class enemybullet : MonoBehaviour {

    public enemydamage stats;
    public int bulldmg;
    public Collider2D attktrigger;
    public float maxspeed;

    // Use this for initialization
    void OnTriggerStay2D(Collider2D attktrigger)
    {
        if (attktrigger.gameObject.tag == "Player")
        {
            //FindGameObjectWithTag("Enemy");
            attktrigger.SendMessageUpwards("HurtPlayer", bulldmg);

                Destroy(gameObject);
            
        }
    }

    void Start () {
        stats = GameObject.FindGameObjectWithTag("Enemy").GetComponent<enemydamage>();
        
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, maxspeed * Time.deltaTime, 0);

        pos += transform.rotation * velocity;

        transform.position = pos;
    }
}
