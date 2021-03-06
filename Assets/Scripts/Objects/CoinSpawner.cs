using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the random spawning of coins and the coin frenzy reward
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
    private void Awake()
    {
        instance = this;
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
    private void Update()
    {
        if (!frenzy)//if frenzy is not active spawn coin at random intervails
        {
            timeSinceLastSpawn += Time.deltaTime;
            if (timeSinceLastSpawn >= nextSpawnTime)
            {
                timeSinceLastSpawn -= nextSpawnTime;
                nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
                SpawnCoin();
            }
        }
        else//if frenzy is active spawn coins is sinusoidal pattern
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
        frenzySpawnPosition.y += ((maxPositionY - minPositionY) * 0.5f) * Mathf.Sin(alpha);
        Instantiate(coin, frenzySpawnPosition, Quaternion.identity);
        frenzyCoinsSpawned++;
        if (frenzyCoinsSpawned >= frenzyCoinsToSpawn)
            frenzy = false;
    }
    public void StartFrenzy()
    {
        frenzy = true;
        frenzySpawnOriginPosition = transform.position;
        frenzySpawnOriginPosition.y = ((maxPositionY - minPositionY) * 0.5f) + minPositionY;
        frenzyCoinsSpawned = 0;
        alpha = 0;
        timeSinceLastSpawn = 0;
    }
}
