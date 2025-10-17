using System.Collections.Generic;
using UnityEngine;

namespace COU.Optimization
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _poolSize;

        private Queue<GameObject> _objectPool = new();
        
        public void Initialize()
        {
            for (var i = 0; i < _poolSize; i++)
            {
                AddObject();
            }
        }

        private void AddObject()
        {
            var obj = Instantiate(_prefab, transform);
            _objectPool.Enqueue(obj);
            obj.SetActive(false);
        }

        public GameObject Spawn(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            if (_objectPool.Count <= 0) 
                AddObject();
            
            var obj = _objectPool.Dequeue();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.transform.parent = parent;
            obj.SetActive(true);
            
            return obj;
        }

        public void Despawn(GameObject obj)
        {
            obj.transform.SetParent(transform);
            obj.transform.position = Vector3.zero;
            obj.transform.rotation = Quaternion.identity;
            obj.SetActive(false);
            _objectPool.Enqueue(obj);
        }
    }
}