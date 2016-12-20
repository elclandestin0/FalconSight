using UnityEngine;
using System.Collections;

public class FirstWeakSpot : MonoBehaviour {

    public static int countHit;
    AudioSource audioSource;
    public AudioClip hurt; 

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            audioSource.PlayOneShot(hurt);
            countHit += 1;
            Destroy(col.gameObject);
        }
    }
}
