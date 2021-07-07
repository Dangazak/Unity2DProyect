using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the spawning of obstacles, "loot boxes", the speed of the game and its difficulty
public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    [SerializeField] GameObject lootBox;
    [SerializeField] float minTimeBetweenSpawns, maxTimeBetweenSpawns, timeBetweenSpeedUps, speedUpAmount, obstacleUnlockRate;
    [SerializeField] int lootChance;
    float timeToNextSpawn, timeSinceLastSpawn, timeSinceLastSpeedUp;
    GameObject nextObjectToSpawn;
    int activeObstacles;
    bool lootSpawnCheck;
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
            lootSpawnCheck = false;
        }
        else if (timeSinceLastSpawn * 2 >= timeToNextSpawn && !lootSpawnCheck)
        {
            LootSpawn();
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
    void LootSpawn()
    {
        lootSpawnCheck = true;
        int randomNumber = Random.Range(0, 100);
        if (randomNumber < lootChance)
        {
            lootChance = 0;
            Instantiate(lootBox);
        }
        else
        {
            lootChance++;
        }
    }
}
