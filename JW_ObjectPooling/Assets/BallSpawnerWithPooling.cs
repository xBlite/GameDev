using UnityEngine;

public class BallSpawnerWithPooling : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1000)]
    private int frequency = 50;
 
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
        var ball = BallPool.Instance.Get();
        ball.transform.position = GetRandomLocation();
        ball.gameObject.SetActive(true);
    }

    private Vector3 GetRandomLocation()
    {
        return transform.position + UnityEngine.Random.onUnitSphere * 5f;
    }

}
