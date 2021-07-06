using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public static CoinSpawner instance;
    [SerializeField] GameObject coin;
    [SerializeField] float minSpawnTime, maxSpawnTime, minPositionY, maxPositionY, frenzySpawnTime, frenzyAlphaVariation;
    [SerializeField] int frenzyCoinsToSpawn;
    public bool frenzy;
    float timeSinceLastSpawn, nextSpawnTime, timeSinceLastFrenzySpawn, alpha;
    int frenzyCoinsSpawned;
    Vector3 frenzySpawnOriginPosition;
    private void Start()
    {
        instance = this;
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
    private void Update()
    {
        if (!frenzy)
        {
            timeSinceLastSpawn += Time.deltaTime;
            if (timeSinceLastSpawn >= nextSpawnTime)
            {
                timeSinceLastSpawn -= nextSpawnTime;
                nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
                SpawnCoin();
            }
        }
        else
        {
            timeSinceLastFrenzySpawn += Time.deltaTime;
            alpha += frenzyAlphaVariation * Time.deltaTime;
            if (timeSinceLastFrenzySpawn >= frenzySpawnTime)
            {
                timeSinceLastFrenzySpawn -= frenzySpawnTime;
                SpawnFrenzyCoin();
            }
        }
    }
    void SpawnCoin()
    {
        Vector3 spawnPosition = transform.position;
        spawnPosition.y = Random.Range(minPositionY, maxPositionY);
        Instantiate(coin, spawnPosition, Quaternion.identity);
    }
    void SpawnFrenzyCoin()
    {
        Vector3 frenzySpawnPosition = frenzySpawnOriginPosition;
        frenzySpawnPosition.y += (maxPositionY - minPositionY) * Mathf.Sin(alpha);
    }
    public void StartFrenzy()
    {
        frenzySpawnOriginPosition = transform.position;
        frenzySpawnOriginPosition.y = maxPositionY - minPositionY;
        frenzyCoinsSpawned = 0;
        alpha = 0;
        SpawnFrenzyCoin();
    }
}
