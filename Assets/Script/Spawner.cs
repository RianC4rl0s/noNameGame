using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    public Transform spawnPoint;
    public float SpawnTime =10;
    public float currentSpawnTime;
    void Start()
    {
        currentSpawnTime = SpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpawnTime -= Time.deltaTime;


        if(currentSpawnTime <= 0)
		{
            Instantiate(enemy, spawnPoint.transform);
            currentSpawnTime = SpawnTime;
		}
    }
}
