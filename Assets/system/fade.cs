using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fade : MonoBehaviour {
    public float transitionTime = 1.0f;
    public timecode levelgoing;
    public bool fadeIn;
    public bool fadeOut;

    public Image fadeImg;

    public float time = 0f;

    void Start()
    {
        StartCoroutine("whiteout");
    }

    void Update()
    {
        //Debug purpposes
        /*
        if (Input.GetButtonDown("decline"))
        {
            StartCoroutine("whitein");
        }

        if (Input.GetButtonDown("interact"))
        {
            StartCoroutine("whiteout");
        }*/
    }

    IEnumerator whiteout()
    {
        time = 1.0f;
        yield return null;
        while (time >= 0.0f)
        {
            fadeImg.color = new Color(0, 0, 0, time);
            time -= Time.deltaTime * (1.0f / transitionTime);
            yield return null;
        }
        //fadeImg.gameObject.SetActive(false);
    }

    IEnumerator whitein()
    {
        time = 0.0f;
        yield return null;
        while (time <= 1.0f)
        {
            fadeImg.color = new Color(fadeImg.color.r, fadeImg.color.g, fadeImg.color.b, time);
            time += Time.deltaTime * (1.0f / transitionTime);
        }
        if (levelgoing.level == 5) { SceneManager.LoadScene("finalcutscene"); }
    }

}
