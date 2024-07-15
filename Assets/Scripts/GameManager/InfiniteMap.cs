using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteMap : MonoBehaviour
{
    
   [SerializeField] private GameObject mapChunk;

   [SerializeField] private float mapChunkSize;

    private void Start()
    {
        updateMap();
    }

    private void updateMap()
    {
        for (int xAxis = -1; xAxis <= 1; xAxis++)
        {
            for(int yAxis = -1; yAxis <= 1; yAxis++)
            {
                updateMapChunk(xAxis, yAxis);
            }
        }
    }

    private void updateMapChunk(int xAxis, int yAxis)
    {
        Vector3 spawnPos = new Vector3 (xAxis, yAxis, 0) * mapChunkSize;
        Instantiate(mapChunk, spawnPos, Quaternion.identity, transform);
    }
}

