using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class EntitySpawner : MonoBehaviour
{
    public bool hasStarted = false;

    [SerializeField]
    private GameObject[] enemyPrefabs;
    [SerializeField]
    private GameObject[] coinPrefabs;
    [SerializeField]
    private GameObject fixPrefab;

    [SerializeField]
    private Transform[] spawnPoints;

    [SerializeField]
    float timeBetweenSpawns = 5f;

    float timer;
    int curEnemyCount = 0;

    private void Start()
    {
        timer = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = timeBetweenSpawns;

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                float randomNumber = Random.Range(1f, 100f);

                if (randomNumber <= 30 && curEnemyCount < 2) // (30%)
                {
                    // SPAWN ENEMY
                    curEnemyCount += 1;
                    Debug.Log("ENEMY");
                    Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPoints[i]);
                }
                else if (randomNumber > 30 && randomNumber <= 60) // (30%)
                {
                    float coinRandomNumber = Random.Range(1f, 100f);

                    if (coinRandomNumber <= 40)
                    {
                        // SPAWN 1 VALUE COIN (40%)
                        Instantiate(coinPrefabs[0], spawnPoints[i]);
                    }
                    else if (coinRandomNumber > 40 && coinRandomNumber <= 70)
                    {
                        // SPAWN 2 VALUE COIN (30%)
                        Instantiate(coinPrefabs[1], spawnPoints[i]);
                    }
                    else if (coinRandomNumber > 70 && coinRandomNumber <= 90)
                    {
                        // SPAWN 3 VALUE COIN (20%)
                        Instantiate(coinPrefabs[2], spawnPoints[i]);
                    }
                    else if (coinRandomNumber > 90)
                    {
                        // SPAWN 4 VALUE COIN (10%)
                        Instantiate(coinPrefabs[3], spawnPoints[i]);
                    }
                    
                }
                else if (randomNumber > 60 && randomNumber <= 65) // (5%)
                {
                    // SPAWN SPANNER
                    Instantiate(fixPrefab, spawnPoints[i]);
                }
            }

            curEnemyCount = 0;
        }
    }
}
