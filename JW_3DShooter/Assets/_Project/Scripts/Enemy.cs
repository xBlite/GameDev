using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace _Project.Scripts
{
    public class Enemy : MonoBehaviour
    {
        private NavMeshAgent _enemyNavAgent;
        private Player _player;
        
        [SerializeField] private float _health = 10f;
        [SerializeField] private GameObject _onHitEffect;
        [SerializeField] private GameObject _onDeathEffect;
        
        private Queue<GameObject> _pool = new Queue<GameObject>();
        
        void Awake()
        {
            _player = FindObjectOfType<Player>(); //Cache player
            _enemyNavAgent = this.GetComponent<NavMeshAgent>(); //Cache NavMeshAgent
            
            _enemyNavAgent.SetDestination(_player.transform.position);
        }

        private void Update()
        {
            _enemyNavAgent.SetDestination(_player.transform.position);
        }

        public void TakeDamage(int damage, Vector3 impactPoint)
        {
            _health -= damage;

            if (_health <= 0)
            {
                Instantiate(_onDeathEffect, impactPoint, Quaternion.identity); //How to pool Animation Effects?
                this.gameObject.SetActive(false);
            }

            Instantiate(_onHitEffect, impactPoint, Quaternion.identity);
        }
    }
}
