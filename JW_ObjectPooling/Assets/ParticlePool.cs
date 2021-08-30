using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    public static ParticlePool Instance { get; private set; }

    [SerializeField]
    private ParticleSystem prefab;

    private Queue<ParticleSystem> particleAvailable = new Queue<ParticleSystem>();

    private void Awake()
    {
        Instance = this;
    }

    public ParticleSystem Get()
    {
        if (particleAvailable.Count == 0)
        {
            return AddBall();
        }

        return particleAvailable.Dequeue();
    }

    private ParticleSystem AddBall()
    {
        var particle = Instantiate(prefab);
        return particle;
    }

    public void Return(ParticleSystem particle)
    {
        particleAvailable.Enqueue(particle);
    }
}
