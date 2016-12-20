using UnityEngine;
using System.Collections;

public class EnemyFire : MonoBehaviour
{
    public float DownwardForce;
    //public GameObject EnemyBulletBarrel;
    public GameObject EnemyBullet;
    public GameObject Target;

    public float waitTime;
    public bool didShoot = false;
    public float bulletForce;
    int shootingTimes = 0;

    Vector3 bulletPosition;
    Vector3 targetPosition;

    AudioSource audioSource;
    public AudioClip shoot;

    // Use this for initialization
    void Start()
    {
      
       audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        waitTime -= Time.deltaTime;
        bulletPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2.0f);

        
        if (waitTime <= 0.0f && didShoot == false)
        {
            audioSource.PlayOneShot(shoot);
            shootingTimes++;
            if (shootingTimes == 2)
                didShoot = true;
            Debug.Log("Enemy fire! Take cover!");
            waitTime = 3.0f;
            //audioSource.PlayOneShot(shoot);
            GameObject Clone;
            Clone = (Instantiate(EnemyBullet, bulletPosition, transform.rotation)) as GameObject;
            Clone.GetComponent<Rigidbody>().velocity = new Vector3(GameObject.Find("Player").transform.position.x - transform.position.x, GameObject.Find("Player").transform.position.y - transform.position.y, GameObject.Find("Player").transform.position.z - transform.position.z).normalized * bulletForce;
            Destroy(Clone, 3.0f);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
