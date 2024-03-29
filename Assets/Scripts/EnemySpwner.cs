﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mirror;
public class EnemySpwner : NetworkBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", this.spawnInterval, this.spawnInterval);   
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector3(Random.Range(-4f, 4f), this.transform.position.y, Random.Range(-4f, 4f));
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity) as GameObject;
        NetworkServer.Spawn(enemy);
        Destroy(enemy, 10f);
    }
}
