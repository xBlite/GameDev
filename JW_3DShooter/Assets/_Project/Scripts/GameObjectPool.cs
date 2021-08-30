using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts
{
    public class GameObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        
        public static GameObjectPool Instance { get; private set; }
        private Queue<GameObject> _objects = new Queue<GameObject>();

        private void Awake()
        {
            Instance = this;
        }

        public GameObject Get()
        {
            if (_objects.Count == 0)
                AddObjects(1);

            return _objects.Dequeue();
        }

        public void ReturnToPool(GameObject obj)
        {
            obj.SetActive(false);
            _objects.Enqueue(obj);
        }

        private void AddObjects(int count)
        {
            var newObj = GameObject.Instantiate(_prefab);
            newObj.SetActive(false);
            _objects.Enqueue(newObj);

            newObj.GetComponent<IGameObjectPooled>().Pool = this;
        }
    }
    internal interface IGameObjectPooled
    {
        GameObjectPool Pool { get; set; }
    }
}