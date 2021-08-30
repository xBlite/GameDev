using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private GameObject particlePrefab;

    private void OnCollisionEnter(Collision collision)
    {
        SpawnParticle(collision.contacts[0].point);
        Destroy(gameObject);
    }

    private void SpawnParticle(Vector3 point)
    {
        var particle = Instantiate(particlePrefab, point, Quaternion.identity);
        Destroy(particle.gameObject, 2f);
    }
}