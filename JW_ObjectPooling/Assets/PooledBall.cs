using System.Collections;
using UnityEngine;

public class PooledBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        SpawnParticle(collision.contacts[0].point);

        // disabled and returned to the pool instead of destroyed
        gameObject.SetActive(false);
        BallPool.Instance.Return(this);
    }

    private void SpawnParticle(Vector3 point)
    {
        var particle = ParticlePool.Instance.Get();
        particle.transform.position = point;
        particle.gameObject.SetActive(true);
        particle.Play();
    }
}