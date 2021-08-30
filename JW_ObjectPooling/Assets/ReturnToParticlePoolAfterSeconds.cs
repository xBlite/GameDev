using UnityEngine;

public class ReturnToParticlePoolAfterSeconds : MonoBehaviour
{
    private ParticleSystem particle;
    private float lifetime;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        lifetime = 0f;
        particle.Play();
    }

    private void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime >= 2f)
        {
            ParticlePool.Instance.Return(particle);
            gameObject.SetActive(false);
        }
    }
}