using UnityEngine;
using System.Collections;

public class sfxmanager : MonoBehaviour {

    public AudioSource snankeIdle;
    public AudioSource snanakeHurt;
    public AudioSource playerHurt;

    public AudioSource ghostieHurt;

    public AudioSource enemyHurt;

    public AudioSource shootSfx;
    public AudioSource freshizaHurt;
    public AudioSource freshizaLaugh;

    private static bool sfxmanexists;


	void Start () {
        if (!sfxmanexists) { sfxmanexists = true; DontDestroyOnLoad(transform.gameObject); } else { Destroy(gameObject); }
	}
	

	void Update () {
	
	}
}
