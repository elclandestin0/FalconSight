using UnityEngine;
using System.Collections;

public class PowerUpOne : MonoBehaviour
{
    public static bool PickedUpPowerUp = false;
    Rigidbody temporaryRigidBody;
    public float downwardForce;
    public static int count;

    public float smooth = 2.0F;
    public float tiltAngle = 30.0F;
  

  //  AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
       // audioSource = GetComponent<AudioSource>();
        temporaryRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.up * Time.deltaTime);
        
        temporaryRigidBody.velocity = new Vector3(0, -downwardForce, 0);

        //Destroy (gameObject, 5.0f);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {

            //audioSource.Play();
            Destroy(gameObject, 0.2f);
            PickedUpPowerUp = true;
            count += 1;
            Debug.Log("Picked Up Powerup!");
            if (PickedUpPowerUp == true)
                GetComponent<Collider>().enabled = false;
        }

    }
}
