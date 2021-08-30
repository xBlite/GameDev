﻿using System.Collections.Generic;
using _Project.Scripts;
using UnityEngine;

namespace _Project.Scripts
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private float _delay = 0.2f;
        [SerializeField] private float _bulletSpeed = 15f;
        [SerializeField] private Vector3 _direction;
    
        private double _nextShootTime;
        private Queue<Bullet> _pool = new Queue<Bullet>();

        private void Update()
        {
            //Raycast from camera hits a collider generating a point to shoot at
            //We remove the y component to shoot in the x and z direction
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var raycastHit, Mathf.Infinity))
            {
                _direction = (raycastHit.point - _shootPoint.position).normalized;
                _direction = new Vector3(_direction.x, 0, _direction.z);
                transform.forward = _direction;
            }
        
            //Checks bulletdelay and other factors to determine if the gun will shoot on this frame
            if (CanShoot()) 
                Shoot();
        }
    
        private bool CanShoot()
        {
            return Time.time >= _nextShootTime;
        }

        private void Shoot()
        {
            _nextShootTime = Time.time + _delay;
            //Create bullet and set the velocity to shoot in direction of mouse
            var bullet = GetBullet();
            var transform1 = bullet.transform;
            transform1.position = _shootPoint.position;
            transform1.rotation = _shootPoint.rotation;
            bullet.GetComponent<Rigidbody>().velocity = _direction * _bulletSpeed;
        }

        private Bullet GetBullet()
        {
            Bullet bullet;

            if (_pool.Count > 0)
            {
                bullet = _pool.Dequeue();
                bullet.gameObject.SetActive(true);
                return bullet;
            }

            bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
            bullet.SetGun(this);
            return bullet;
        }

        internal void AddToPool(Bullet bullet)
        {
            _pool.Enqueue(bullet);
        }
    }
}

