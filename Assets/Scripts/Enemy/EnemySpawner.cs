using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float initialSpawnTime;
    private float spawnTime;

    private void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            Vector3 spawnPos = GetSpawnPos();
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            spawnTime = initialSpawnTime;
        }
    }

    private Vector3 GetSpawnPos()
    {
        Camera mainCamera = Camera.main;
        Vector3 spawnPos = Vector3.zero;

        // Rand side to spawn
        int side = Random.Range(0, 4);

        // Random pos
        switch (side)
        {
            case 0: // Top
                spawnPos = mainCamera.ViewportToWorldPoint(new Vector3(Random.value, 1.2f, 0));
                break;
            case 1: // Bottom
                spawnPos = mainCamera.ViewportToWorldPoint(new Vector3(Random.value, -0.2f, 0));
                break;
            case 2: // Left
                spawnPos = mainCamera.ViewportToWorldPoint(new Vector3(-0.2f, Random.value, 0));
                break;
            case 3: // Right
                spawnPos = mainCamera.ViewportToWorldPoint(new Vector3(1.2f, Random.value, 0));
                break;
        }

        return spawnPos;
    }
}
