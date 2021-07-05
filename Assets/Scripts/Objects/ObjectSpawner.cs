using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    [SerializeField] GameObject coin, lootBox;
    [SerializeField] float minTimeBetweenSpawns, maxTimeBetweenSpawns, breakTimeDuration, timeBetweenSpeedUps, speedUpAmount, obstacleUnlockRate;
    [SerializeField] int coinChance, lootChance, breakChance;
    float timeToNextSpawn, timeSinceLastSpawn, timeSinceLastSpeedUp, breakTime;
    GameObject nextObjectToSpawn;
    int activeObstacles;
    bool isBreakTime;
    GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.Instance;
        nextObjectToSpawn = obstacles[0];
        activeObstacles = 1;
    }
    void Update()
    {
        timeSinceLastSpeedUp += Time.deltaTime;
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpeedUp >= timeBetweenSpeedUps)
        {
            timeSinceLastSpeedUp -= timeBetweenSpeedUps;
            gameManager.SpeedChange(speedUpAmount);
            NewObstacleUnlockCheck();
        }
        if (timeSinceLastSpawn >= timeToNextSpawn)
        {
            timeSinceLastSpawn -= timeToNextSpawn;
            SpawnObstacle();
        }
    }
    public void SpawnObstacle()
    {
        timeToNextSpawn = nextObjectToSpawn.GetComponent<ObjectControl>().spawnTimeDelay;
        Instantiate(nextObjectToSpawn);
        nextObjectToSpawn = obstacles[Random.Range(0, activeObstacles)];
        timeToNextSpawn += nextObjectToSpawn.GetComponent<ObjectControl>().spawnTimeDelay;
        timeToNextSpawn += Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
    }
    void NewObstacleUnlockCheck()
    {
        if (gameManager.gameSpeed > 1 + activeObstacles * obstacleUnlockRate)
            activeObstacles++;
        if (activeObstacles > obstacles.Length)
            activeObstacles = obstacles.Length;
    }
}
