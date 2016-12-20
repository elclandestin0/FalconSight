using UnityEngine;
using System.Collections;

public class EnemyOne : MonoBehaviour 
{

    Rigidbody temporaryRigidBody;
    public float delay; // for animation 
    bool enemyDies = false;
    public float enemySpeed;
    public float waitTimeToDestroy = 10.0f;

    AudioSource audioSource;
    public AudioClip die; 
    // animation component add here
    // audiosource component add here
 


	// Use this for initialization
	void Start ()
    {
        temporaryRigidBody = GetComponent<Rigidbody>();
        gameObject.GetComponent<ParticleSystem>().enableEmission = false;
        audioSource = GetComponent<AudioSource>();
        // animation component
        // audiosource component 
        
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (enemyDies == false)
            temporaryRigidBody.velocity = new Vector3(0, 0, -enemySpeed);
        waitTimeToDestroy -= Time.deltaTime;

        if (waitTimeToDestroy <= 0.0f)
            Destroy(gameObject);
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            audioSource.PlayOneShot(die);
            gameObject.GetComponent<ParticleSystem>().enableEmission = true;
            enemyDies = true;
            if (enemyDies == true)
            {
                Destroy(collider.gameObject);
                //GetComponent<Collider>().enabled = false;
                temporaryRigidBody.useGravity = true;
            }
            // add audio source play dying effect
           // Destroy(gameObject);
            Debug.Log("Enemy one shot down!!");
        }
        else if (collider.gameObject.tag == "Planet")
        {
            Destroy(gameObject);
            Debug.Log("Collided with planet! Boom!!");
            Score.playerScore += 100;
        }

        else if (collider.gameObject.tag == "Player")
        {
            Destroy(collider.gameObject);
        }
    }

    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }
}
