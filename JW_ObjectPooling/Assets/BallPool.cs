using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    public static BallPool Instance { get; private set; }

    [SerializeField]
    private PooledBall prefab;

    private Queue<PooledBall> ballsAvailable = new Queue<PooledBall>();

    private void Awake()
    {
        Instance = this;
    }

    public PooledBall Get()
    {
        if (ballsAvailable.Count == 0)
        {
            return AddBall();
        }

        return ballsAvailable.Dequeue();
    }

    private PooledBall AddBall()
    {
        var ball = Instantiate(prefab);
        return ball;
    }

    public void Return(PooledBall ball)
    {
        ballsAvailable.Enqueue(ball);
    }
}
