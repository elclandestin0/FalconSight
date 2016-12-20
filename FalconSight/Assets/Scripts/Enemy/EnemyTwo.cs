using UnityEngine;
using System.Collections;

public class EnemyTwo : MonoBehaviour 
{
    Rigidbody temporaryRigidBody;
    bool enemyTwoDies = false;
    public float enemySpeed;
    public float offset;
    float waitTime = 0.5f;
    bool collidedWithSelf;

    public AudioClip die; 

    float waitTimeToDestroy = 16.0f;
    AudioSource audioSource; 

	// Use this for initialization
	void Start () 
    {
        temporaryRigidBody = GetComponent<Rigidbody>();
        gameObject.GetComponent<ParticleSystem>().enableEmission = false;
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        waitTimeToDestroy -= Time.deltaTime;
        if (waitTimeToDestroy <= 0.0f)
            Destroy(gameObject);

        if (enemyTwoDies == false)
        {
            temporaryRigidBody.velocity = new Vector3(enemySpeed, 0, 0);

            if (enemyTwoDies == false && transform.position.x >= 39.2f)
                temporaryRigidBody.velocity = new Vector3(0, 0, -enemySpeed);
        }

        if (enemyTwoDies == false && transform.position.z <= 8.0f)
        {
            temporaryRigidBody.velocity = new Vector3(-enemySpeed, 0, 0);

            if (enemyTwoDies == false && transform.position.x <= -36.0f)
                temporaryRigidBody.velocity = new Vector3(0, 0, -enemySpeed);
        }

        if (enemyTwoDies == false && transform.position.z <= 4.0f)
        {
            temporaryRigidBody.velocity = new Vector3(enemySpeed, 0, 0);
            if (enemyTwoDies == false && transform.position.x >= 0.0f)
                temporaryRigidBody.velocity = new Vector3(0, 0, 0);
        }
	}
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            audioSource.PlayOneShot(die);
            gameObject.GetComponent<ParticleSystem>().enableEmission = true;
            enemyTwoDies = true;
            if (enemyTwoDies == true)
            {
                Destroy(collider.gameObject);
                temporaryRigidBody.useGravity = true;
                Debug.Log("Enemy one shot down!!");
            }
        }
            
        else if (collider.gameObject.tag == "Planet")
        {
           
            Destroy(gameObject);
            Debug.Log("Collided with planet! Boom!!");
            Score.playerScore += 200;
        }

        else if (collider.gameObject.tag == "EnemyTwo")
        {
            collidedWithSelf = true;
        }

        
    }
}
