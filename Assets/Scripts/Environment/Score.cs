using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    public static int playerScore;
    //public GameObject Bullet; 

    public GameObject player;

    public GameObject FirstPowerUp;
    public GameObject SecondPowerUp;
    public GameObject ThirdPowerUp;
    public GameObject FourthPowerUp;

    bool generateFirstPowerUp = false;
    bool generateSecondPowerUp = false;
    bool generateThirdPowerUp = false;
    bool generateFourthPowerUp = false;


    Vector2 minimumRange = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    Vector2 maximumRange = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

   // AudioSource audioSource;
   // public AudioClip generatePowerUp;

    // Use this for initialization
    void Start()
    {
       // audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScore >= 1000 && generateFirstPowerUp == false)
        {
            
            //audioSource.PlayOneShot(generatePowerUp);
            generateFirstPowerUp = true;
            GameObject firstPowerUp = (GameObject)Instantiate(FirstPowerUp);
            firstPowerUp.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2.0f, player.transform.position.z - 7.0f);
            Debug.Log("First power up generated!");
             

        }
        else if (playerScore >= 2000 & generateSecondPowerUp == false)
        {
            
            //audioSource.PlayOneShot(generatePowerUp);
            generateSecondPowerUp = true;
            GameObject secondPowerUp = (GameObject)Instantiate(SecondPowerUp);
            secondPowerUp.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2.0f, player.transform.position.z - 7.0f);
            Debug.Log("Second power up generated!");
             
        }

        else if (playerScore >= 3000 & generateThirdPowerUp == false)
        {
           // audioSource.PlayOneShot(generatePowerUp);
           generateThirdPowerUp = true;
           GameObject thirdPowerUp = (GameObject)Instantiate(ThirdPowerUp);
           thirdPowerUp.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2.0f, player.transform.position.z - 7.0f);
           Debug.Log("Third power up generated!");
        }

        else if (playerScore >= 4000 & generateFourthPowerUp == false)
        {
            
           // audioSource.PlayOneShot(generatePowerUp);
            generateFourthPowerUp = true;
            GameObject fourthPowerUp = (GameObject)Instantiate(FourthPowerUp);
            fourthPowerUp.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2.0f, player.transform.position.z - 7.0f);
            Debug.Log("Fourth power up generated!");
             
        }


    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 40), "Ownage Score: ");
        GUI.Label(new Rect(10, 30, 200, 40), playerScore.ToString());

    }

    void WinningMessage()
    {
        //if (Boss.didWinGame == true)
           // GUI.Label(new Rect(20, 10, 200, 40), "Congratulations!!!");
    }

}
