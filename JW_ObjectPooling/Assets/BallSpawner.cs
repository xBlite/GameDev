using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1000)]
    private int frequency = 50;
    [SerializeField]
    private GameObject ballPrefab;

    private void Update()
    {
        if (ShouldSpawnBall())
            SpawnBall();
    }

    private bool ShouldSpawnBall()
    {
        return UnityEngine.Random.Range(0, 1000) < frequency;
    }

    private void SpawnBall()
    {
        Instantiate(ballPrefab, GetRandomLocation(), Quaternion.identity);
    }

    private Vector3 GetRandomLocation()
    {
        return transform.position + UnityEngine.Random.onUnitSphere * 5f;
    }

}
