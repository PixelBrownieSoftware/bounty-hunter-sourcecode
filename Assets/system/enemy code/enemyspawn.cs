using UnityEngine;
using System.Collections;

public class enemyspawn : MonoBehaviour {

    public float spawnTime;        // The amount of time between each spawn.
    public float spawnDelay;       // The amount of time before spawning starts.
    public GameObject enemy;        // Array of enemy prefabs.

    public static int enemycount;

    public timecode levelgoing;
    public float timelimit;

    void Start()
    {
        levelgoing = GameObject.FindWithTag("Timer").GetComponent<timecode>();
        StartCoroutine(SpawnTimeDelay());
    }

    void Update () {
        timelimit = levelgoing.GetComponent<timecode>().timer;
        if (timelimit < 1)
        {
            Destroy(gameObject);

        }
    }

    IEnumerator SpawnTimeDelay()
    {
        while (timelimit >= 0 && enemyspawn.enemycount <=30) {
            
            Instantiate(enemy, transform.position, Quaternion.identity);
            enemyspawn.enemycount++;
            yield return new WaitForSeconds(spawnTime);

        }  
    }


}
