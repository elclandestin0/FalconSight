using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour
{
    public float scrollSpeed = 0.95f;
    AudioSource audioSource;
    public float waitTimeSpeed;
    public float scrollTime = 10.0f;
    public bool divideOnce = false;

    void Start()
    {
        audioSource.GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        waitTimeSpeed -= Time.deltaTime;
        scrollTime -= Time.deltaTime;
        Vector2 offset;
        offset = new Vector2(0, Time.time * scrollSpeed);
        //renderer.GetComponent<>.
        GetComponent<Renderer>().material.mainTextureOffset = offset;
        
        if (waitTimeSpeed <= 0.0f && !divideOnce)
        {
            divideOnce = true;
            scrollSpeed = scrollSpeed / 2;
        }

        if (scrollTime <= 0.0f)
            scrollSpeed = 0.0f;
         
    }
}
