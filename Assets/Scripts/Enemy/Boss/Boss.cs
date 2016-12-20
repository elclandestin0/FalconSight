using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    Rigidbody temporaryRigidBody;

    public AudioClip die;

    AudioSource audioSource;

    private Vector2 startPosition;
    public static float bossHealth = 100.0f;
    public static bool didWinGame = false;
    public float waitTimeToShoot = 3.0f;

    public bool bossHasArrived = false;

    public GameObject BossBullet;
    public GameObject Target;

    Vector3 bulletPositionOne;
    Vector3 bulletPositionTwo;
    Vector3 bulletPositionThree;

    bool shotFirstBullet = false;
    bool shotSecondBullet = false;
    bool shotThirdBullet = false;

    // Use this for initialization
    void Start()
    {
        temporaryRigidBody = GetComponent<Rigidbody>();
    
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        temporaryRigidBody.velocity = new Vector3(0, 0, -10);
        if (transform.position.z <= 31.7f)
            temporaryRigidBody.velocity = new Vector3(0, 0, 0);

        waitTimeToShoot -= Time.deltaTime;
        bulletPositionOne = new Vector3(transform.position.x - 1.0f, transform.position.y, transform.position.z - 12.0f);
        bulletPositionTwo = new Vector3(bulletPositionOne.x + 1.0f, transform.position.y, transform.position.z - 12.0f);
        bulletPositionThree = new Vector3(bulletPositionOne.x, transform.position.y, transform.position.z - 12.0f);

        if (waitTimeToShoot <= 2.5f && !shotFirstBullet)
        {
            GameObject Clone;
            Clone = (Instantiate(BossBullet, bulletPositionOne, transform.rotation)) as GameObject;
            Clone.GetComponent<Rigidbody>().velocity = new Vector3(GameObject.Find("Player").transform.position.x - transform.position.x, GameObject.Find("Player").transform.position.y - transform.position.y, GameObject.Find("Player").transform.position.z - transform.position.z).normalized * 20.0f;
            Destroy(Clone, 3.0f);
            shotFirstBullet = true;
        }
        else if (waitTimeToShoot <= 1.5f && !shotSecondBullet)
        {
            GameObject CloneTwo;
            CloneTwo = (Instantiate(BossBullet, bulletPositionTwo, transform.rotation)) as GameObject;
            CloneTwo.GetComponent<Rigidbody>().velocity = new Vector3(GameObject.Find("Player").transform.position.x - transform.position.x, GameObject.Find("Player").transform.position.y - transform.position.y, GameObject.Find("Player").transform.position.z - transform.position.z).normalized * 20.0f;
            Destroy(CloneTwo, 3.0f);
            shotSecondBullet = true;
        }

        else if (waitTimeToShoot <= 0.5f && !shotThirdBullet)
        {
            GameObject CloneThree;
            CloneThree = (Instantiate(BossBullet, bulletPositionTwo, transform.rotation)) as GameObject;
            CloneThree.GetComponent<Rigidbody>().velocity = new Vector3(GameObject.Find("Player").transform.position.x - transform.position.x, GameObject.Find("Player").transform.position.y - transform.position.y, GameObject.Find("Player").transform.position.z - transform.position.z).normalized * 20.0f;
            Destroy(CloneThree, 3.0f);
            shotThirdBullet = true;
        }

        if (shotFirstBullet && shotSecondBullet && shotThirdBullet)
        {
            waitTimeToShoot = 3.0f;
            shotFirstBullet = false;
            shotSecondBullet = false;
            shotThirdBullet = false;
        }

        if (Move.destroyed == true)
        {
            GUI.Label(new Rect(300, 90, 200, 40), "GAME OVER!!!");
            Destroy(gameObject);
        }


        if (bossHealth <= 0.0f)
        {
            audioSource.PlayOneShot(die);
            temporaryRigidBody.useGravity = true;
            Destroy(gameObject, 1.0f);
            didWinGame = true;
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(300, 10, 200, 40), "Boss Health: ");
        GUI.Label(new Rect(300, 30, 200, 40), bossHealth.ToString());

        if (didWinGame == true)
            GUI.Label(new Rect(300, 90, 200, 40), "YOU WIN!!!");
    }



}
