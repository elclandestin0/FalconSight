using UnityEngine;
using System.Collections;

public class BossSpawn : MonoBehaviour
{

    public float waitTime = 30.0f;
    public bool spawnBoss = false;
    public GameObject spawnPoint;
    public GameObject Boss;

    Vector2 minimumRange = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    Vector2 maximumRange = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;

        if (waitTime <= 0.0 && spawnBoss == false)
        {
            spawnBoss = true;
            Destroy(spawnPoint.GetComponent<Spawning>());

            GameObject finalBoss = (GameObject)Instantiate(Boss);
            Boss.transform.position = new Vector3(0.0f, 19.2f, 58.1f);

        }



    }
}
