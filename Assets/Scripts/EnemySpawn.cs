using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private int strongest = 1;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemyBoss;
    private int enemyNumber = 3;
    private int bossNumber = 1; 

    public void Spawn()
    {
 
        switch (strongest)
        {
            case 1:
                for (int i = 0; i < enemyNumber; i++)
                {
                    var position = new Vector2(Random.Range( -25.5f,  54.6f), Random.Range( -10.5f,  27.9f));
                    Instantiate(enemy1, position, enemy1.transform.rotation);
                }
                enemyNumber++;
                strongest = strongest + 1;
                break;

            case 2:
                for (int i = 0; i < enemyNumber; i++)
                {
                    var position = new Vector2(Random.Range(-25.5f, 54.6f), Random.Range(-10.5f, 27.9f));
                    Instantiate(enemy1, position, enemy1.transform.rotation);
                }
                enemyNumber++;
                strongest++;
                break;
            case 3:
                for (int i = 0; i < enemyNumber; i++)
                {
                    var position = new Vector2(Random.Range(-25.5f, 54.6f), Random.Range(-10.5f, 27.9f));
                    Instantiate(enemy1, position, enemy1.transform.rotation);
                }
                enemyNumber++;
                strongest++;
                break;
            case 4:
                for (int i = 0; i < enemyNumber; i++)
                {
                    var position = new Vector2(Random.Range(-25.5f, 54.6f), Random.Range(-10.5f, 27.9f));
                    Instantiate(enemy1, position, enemy1.transform.rotation);
                }
                enemyNumber--;
                enemyNumber--;
                strongest++;
                break;
        }
    }
    public void Spawn2()
    {
        switch (strongest)
        {
            case 6:
                for (int i = 0; i < enemyNumber; i++)
                {
                    var position = new Vector2(Random.Range(-25.5f, 54.6f), Random.Range(-10.5f, 27.9f));
                    Instantiate(enemy2, position, enemy2.transform.rotation);
                }
                strongest++;
                break;
            case 7:
                gameObject.SetActive(true); // same as 2
                strongest++;
                break;
            case 8:
                gameObject.SetActive(true); // stronger
                strongest++;
                break;
            case 9:
                gameObject.SetActive(true); // same as 4
                break;
        }
    }
    public void SpawnBoss()
    {
        print(strongest);
        switch (strongest)
        {
            case 5:
                for (int i = 0; i < enemyNumber; i++)
                {
                    var position = new Vector2(Random.Range(-25.5f, 54.6f), Random.Range(-10.5f, 27.9f));
                    Instantiate(enemy2, position, enemy2.transform.rotation);
                }
                for (int i = 0; i < bossNumber; i++)
                {
                    var position = new Vector2(Random.Range(-25.5f, 54.6f), Random.Range(-10.5f, 27.9f));
                    Instantiate(enemyBoss, position, enemyBoss.transform.rotation);
                }
                enemyNumber++;
                strongest++;
                break;
            case 10:
                gameObject.SetActive(true); // stronger
                break;
        }
    }
}

