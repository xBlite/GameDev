using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class EnemySpawner : MonoBehaviour
{
    private double _nextSpawnTime;
    
    [SerializeField] private double _spawnDelay = 5;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private void Update()
    {
        if (ShouldSpawn())
            Spawn();
    }

    private void Spawn()
    {
        _nextSpawnTime = Time.time + _spawnDelay;

        var randomIndex = UnityEngine.Random.Range(0, _spawnPoints.Length);
        var spawnPoint = _spawnPoints[randomIndex];

        Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    private bool ShouldSpawn()
    {
        return Time.time >= _nextSpawnTime;
    }
}
