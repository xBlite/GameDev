using UnityEngine;

namespace _Project.Scripts
{
    public class Bullet : MonoBehaviour
    {
        private Gun _gun;
        [SerializeField] private int _damage = 1;

        public void SetGun(Gun gun) => _gun = gun;
        private void OnCollisionEnter(Collision other)
        {
            BulletPool.Instance.ReturnToPool(this);
            
            var enemy = other.collider.GetComponent<Enemy>();
            if (enemy != null)
                enemy.TakeDamage(_damage, other.contacts[0].point);
            
        }
    }
}