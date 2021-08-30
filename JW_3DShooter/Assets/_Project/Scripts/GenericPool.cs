using System;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T _prefab;
    
    public static GenericObjectPool<T> Instance { get; private set; }
    private Queue<T> _objects = new Queue<T>();

    private void Awake()
    {
        Instance = this;
    }

    public T Get()
    {
        if (_objects.Count == 0)
            AddObjects(1);
        
        return _objects.Dequeue();
    }
    
    public void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive(false);
        _objects.Enqueue(obj);
    }

    private void AddObjects(int count)
    {
        var newObj = GameObject.Instantiate(_prefab);
        newObj.gameObject.SetActive(false);
        _objects.Enqueue(newObj);
    }
}