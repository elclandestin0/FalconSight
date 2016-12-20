using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour 
{
    AudioSource audioSource;
    public AudioClip shoot;
    public AudioClip die; 

	public float planeSpeed; 
	public GameObject bullet;
    public GameObject score;

    bool playerDies;
    public static bool destroyed;

	Vector3 bulletPosition;
    Vector3 bulletPositionTwo;
    Vector3 bulletPositionThree;
    Vector3 bulletPositionFour;
    Vector3 bulletPositionFive;

    public bool firstUpgrade = false;
    public bool secondUpgrade = false;
    public bool thirdUpgrade = false;
    public bool fourthUpgrade = false; 

    public float shootingForce;
	// Use this for initialization
	void Start () 
	{
        audioSource = GetComponent<AudioSource>();
		bulletPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 2.0f);
	}

	// Update is called once per frame
	void Update ()
	{
		bulletPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 2.0f);

		if (Input.GetKey (KeyCode.W)) 
			transform.Translate (Vector3.up * Time.deltaTime * planeSpeed); 

		if (Input.GetKey (KeyCode.S))
			transform.Translate (-Vector3.up * Time.deltaTime * planeSpeed); 

		if (Input.GetKey (KeyCode.A))
			transform.Translate (-Vector3.right * Time.deltaTime * planeSpeed); 
		
		if (Input.GetKey (KeyCode.D))
			transform.Translate (Vector3.right * Time.deltaTime * planeSpeed); 

        
		if (Input.GetKeyDown (KeyCode.Space))
		{
            audioSource.PlayOneShot(shoot);
			GameObject Clone;
			Clone = (Instantiate (bullet, bulletPosition, transform.rotation)) as GameObject; 
			Clone.GetComponent<Rigidbody> ().AddForce (transform.forward * shootingForce);
			Destroy (Clone, 3.0f);
            Vector3 clonePosition = Clone.transform.position;

            if (PowerUpOne.PickedUpPowerUp == true)
            {

                firstUpgrade = true; // for when player takes damage
                bulletPositionTwo = new Vector3(bulletPosition.x + 0.6f, bulletPosition.y, bulletPosition.z - 1.2f);
                GameObject CloneOne;
                CloneOne = (Instantiate(bullet, bulletPositionTwo, transform.rotation)) as GameObject;
                CloneOne.GetComponent<Rigidbody>().AddForce((transform.forward) * shootingForce);
                Destroy(CloneOne, 3.0f);
                if (PowerUpTwo.PickedUpPowerUp == true) 
				{
					secondUpgrade = true; // for when player takes damage
					bulletPositionThree = new Vector3 (bulletPosition.x - 0.6f, bulletPosition.y,  bulletPosition.z - 1.2f);
					GameObject CloneTwo; 
					CloneTwo = (Instantiate (bullet, bulletPositionThree, transform.rotation)) as GameObject;
					CloneTwo.GetComponent<Rigidbody> ().AddForce (transform.forward * shootingForce);
					CloneOne.GetComponent<Rigidbody> ().AddForce (transform.forward * shootingForce);

					Destroy (CloneTwo, 3.0f);

					if (PowerUpThree.PickedUpPowerUp == true) 
					{
						thirdUpgrade = true; // for when player takes damage
						bulletPositionFour = new Vector3 (bulletPosition.x - 0.4f, bulletPosition.y, bulletPosition.z);
						GameObject CloneThree; 
						CloneThree = (Instantiate (bullet, bulletPositionFour, transform.rotation)) as GameObject;
						CloneThree.GetComponent<Rigidbody> ().AddForce ((transform.forward) * shootingForce);
						Destroy (CloneThree, 3.0f);

						if (PowerUpFour.PickedUpPowerUp == true) 
						{
							fourthUpgrade = true; // for when player takes damage
							bulletPositionFive = new Vector3 (bulletPosition.x + 0.4f, bulletPosition.y, bulletPosition.z);
							GameObject CloneFour; 
							CloneFour = (Instantiate (bullet, bulletPositionFive, transform.rotation)) as GameObject;
							CloneFour.GetComponent<Rigidbody> ().AddForce ((transform.forward) * shootingForce);
							Destroy (CloneFour, 3.0f);
						}

					}
						
				}

			}


            }
		}





    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyOne" || other.gameObject.tag == "EnemyTwo" || other.gameObject.tag == "EnemyBullet")
        {
            //Destroy(gameObject);
            if (PowerUpOne.PickedUpPowerUp == true)
                PowerUpOne.PickedUpPowerUp = false;
            else if (PowerUpTwo.PickedUpPowerUp == true)
                PowerUpTwo.PickedUpPowerUp = false;
            else if (PowerUpThree.PickedUpPowerUp == true)
                PowerUpThree.PickedUpPowerUp = false;
            else if (PowerUpFour.PickedUpPowerUp == true)
                PowerUpFour.PickedUpPowerUp = false;

            else
            {
                audioSource.PlayOneShot(die);
                playerDies = true;
               // audioSource.PlayOneShot(die);
                Destroy(gameObject, 1.0f); //, animator.GetCurrentAnimatorStateInfo(0).length + delay);
                if (playerDies == true)
                    GetComponent<Collider>().enabled = false;
                destroyed = true;
            }
        }
    }

}
