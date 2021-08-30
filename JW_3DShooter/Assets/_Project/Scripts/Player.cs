using UnityEngine;

namespace _Project.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _playerSpeed = 5f;
        [SerializeField] private Transform _direction;
    
        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontal, 0f, vertical);
            transform.Translate(movement * Time.deltaTime * _playerSpeed, _direction);
        }
    }
}