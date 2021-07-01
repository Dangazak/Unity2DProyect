using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] float timeBetweenSpawn;
    private void Start()
    {
        InvokeRepeating("SpawnObject", timeBetweenSpawn, timeBetweenSpawn);
    }
    public void SpawnObject()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }
}
