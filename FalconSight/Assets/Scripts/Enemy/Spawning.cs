using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawning : MonoBehaviour
{
    public GameObject EnemyA;
    public GameObject EnemyB;


    // Use this for initialization
    void Start()
    {
        Invoke("SpawnEnemyA", 1f);
        Invoke("SpawnEnemyB", 3f);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void SpawnEnemyA()
    {

        Vector3 minimumRange = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maximumRange = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));

        List<GameObject> enemyAWave = new List<GameObject>();

        GameObject enemyA1 = (GameObject)Instantiate(EnemyA);
        enemyA1.transform.position = new Vector3(Random.Range(-2.33f, 2.71f), 20.61f, 25.0f);
        enemyAWave.Add(enemyA1);

        GameObject enemyA2 = (GameObject)Instantiate(EnemyA);
        enemyA2.transform.position = new Vector3(enemyA1.transform.position.x - 1.4f, enemyA1.transform.position.y, enemyA1.transform.position.z + 1.4f);
        enemyAWave.Add(enemyA2);

        GameObject enemyA3 = (GameObject)Instantiate(EnemyA);
        enemyA3.transform.position = new Vector3(enemyA1.transform.position.x + 1.4f, enemyA1.transform.position.y, enemyA1.transform.position.z + 1.4f);
        enemyAWave.Add(enemyA3);

        GameObject enemyA4 = (GameObject)Instantiate(EnemyA);
        enemyA4.transform.position = new Vector3(enemyA2.transform.position.x - 1.4f, enemyA2.transform.position.y, enemyA2.transform.position.z + 1.4f);
        enemyAWave.Add(enemyA4);

        GameObject enemyA5 = (GameObject)Instantiate(EnemyA);
        enemyA5.transform.position = new Vector3(enemyA3.transform.position.x + 1.4f, enemyA3.transform.position.y, enemyA3.transform.position.z + 1.4f);
        enemyAWave.Add(enemyA5);

        if (enemyAWave.Count == 0)
            Debug.Log("Drop Power Up!");

        Invoke("SpawnEnemyA", Random.Range(1f, 3f));
    }

    void SpawnEnemyB()
    {
        Vector2 minimumRange = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector2 maximumRange = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));

        float switchNumber = Random.Range(0, 2) * 1 - 1;

        //float offset;

        GameObject enemyB1 = (GameObject)Instantiate(EnemyB);
        enemyB1.transform.position = new Vector3(-30.3f, 22.0f, 21.7f);

        GameObject enemyB2 = (GameObject)Instantiate(EnemyB);
        enemyB2.transform.position = new Vector3(enemyB1.transform.position.x - 3.5f, enemyB1.transform.position.y, enemyB1.transform.position.z);

        GameObject enemyB3 = (GameObject)Instantiate(EnemyB);
        enemyB3.transform.position = new Vector3(enemyB2.transform.position.x - 3.5f, enemyB2.transform.position.y, enemyB2.transform.position.z);

        GameObject enemyB4 = (GameObject)Instantiate(EnemyB);
        enemyB4.transform.position = new Vector3(enemyB3.transform.position.x - 3.5f, enemyB3.transform.position.y, enemyB3.transform.position.z);

        GameObject enemyB5 = (GameObject)Instantiate(EnemyB);
        enemyB5.transform.position = new Vector3(enemyB4.transform.position.x - 3.5f, enemyB4.transform.position.y, enemyB4.transform.position.z);

        Invoke("SpawnEnemyB", Random.Range(2f, 4f));
    }
}
