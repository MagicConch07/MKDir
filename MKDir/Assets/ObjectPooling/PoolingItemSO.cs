using System;
using UnityEngine;

namespace MKDir.ObjectPooling
{
    [CreateAssetMenu(menuName = "SO/Pool/PoolItem")]
    public class PoolingItemSO : ScriptableObject
    {
        public string enumName;
        public string poolingName;
        public string description;
        public int poolCount;
        public GameObject poolObject;
        public IPoolable prefab;

        private void OnValidate()
        {
            if (poolObject == null)
            {
                Debug.LogWarning("Object Null!");
                return;
            }
            prefab = poolObject.GetComponent<IPoolable>();

            if (prefab != null)
            {
                if (enumName != prefab.Type.ToString())
                {
                    prefab = null;
                    Debug.LogWarning("Type mismatch!");
                }
            }
        }
    }
}
