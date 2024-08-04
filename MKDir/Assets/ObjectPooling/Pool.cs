using System.Collections.Generic;
using UnityEngine;

namespace MKDir.ObjectPooling
{
    public class Pool<T> where T : IPoolable
    {
        private Stack<T> _pool = new Stack<T>();
        private T _prefab;
        private Transform _parentTrm;
        private PoolingType _type;

        public Pool(T prefab, PoolingType type, Transform parent, int count)
        {
            _prefab = prefab;
            _type = type;
            _parentTrm = parent;

            for (int i = 0; i < count; ++i)
            {
                T item = CreatePoolObject(_prefab.PoolObject, _parentTrm, _type.ToString(), false);
                _pool.Push(item);
            }
        }

        public T Pop()
        {
            T item = default(T);

            if (_pool.Count == 0)
            {
                item = CreatePoolObject(_prefab.PoolObject, _parentTrm, _type.ToString());
            }
            else
            {
                item = _pool.Pop();
                item.PoolObject.SetActive(true);
            }

            return item;
        }

        public void Push(T item)
        {
            item.PoolObject.SetActive(false);
            _pool.Push(item);
        }

        private T CreatePoolObject(GameObject prefab, Transform parentTrm, string name, bool active = true)
        {
            GameObject obj = GameObject.Instantiate(prefab, parentTrm);
            obj.SetActive(active);
            obj.name = name;

            return obj.GetComponent<T>();
        }
    }
}
