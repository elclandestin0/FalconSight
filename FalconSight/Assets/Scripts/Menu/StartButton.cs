using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class StartButton : MonoBehaviour
{
    bool playOnce = false;

    public Sprite menuButton;
    public Sprite menuButtonDown;

    public bool insideSprite = false;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!playOnce)
        {
            audioSource.Play();
            playOnce = true;
        }
        if (Input.GetMouseButtonDown(0) && insideSprite == true)
        {
            SceneManager.LoadScene("first");
            Debug.Log("can click");
        }

    }

    void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().sprite = menuButton;
        insideSprite = true;
        Debug.Log("can click to first scene");

    }

    void OnMouseExit()
    {
        insideSprite = false;
        GetComponent<SpriteRenderer>().sprite = menuButtonDown;
        Debug.Log("Exit sprite");
    }

}
