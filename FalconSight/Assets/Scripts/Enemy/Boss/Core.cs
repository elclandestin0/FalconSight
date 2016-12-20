using UnityEngine;
using System.Collections;

public class Core : MonoBehaviour
{
    public float waitTime = 0.0f;
    public bool openCore = false;
    public AudioClip hurt;
    AudioSource audioSource; 

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    { 
        
        waitTime -= Time.deltaTime;

        if (FirstWeakSpot.countHit >= 2 && SecondWeakSpot.countHit >= 2 && !openCore)
        {
            waitTime = 5.0f;
            Debug.Log("Core is open!");
            openCore = true;
           
        }

        if (waitTime <= 0.0f && openCore)
        {
            FirstWeakSpot.countHit = 0;
            SecondWeakSpot.countHit = 0;
            openCore = false;
            Debug.Log("Time's up!");
        }
         
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet" && FirstWeakSpot.countHit >= 2 && SecondWeakSpot.countHit >= 2 && openCore)
        {
            audioSource.PlayOneShot(hurt);
            Destroy(col.gameObject);
            Boss.bossHealth -= 6.67f;
        }

        else if (col.gameObject.tag == "Planet")
        {
            Destroy(gameObject);
        }
    }

}
