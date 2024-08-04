using System.Collections.Generic;
using UnityEngine;

namespace MKDir.ObjectPooling
{
    public class PoolManager : MonoSingleton<PoolManager>
    {
        private Dictionary<PoolingType, Pool<IPoolable>> _pools = new Dictionary<PoolingType, Pool<IPoolable>>();
        public PoolingTableSO listSO;

        protected override void Awake()
        {
            base.Awake();

            foreach (PoolingItemSO item in listSO.poolDatas)
            {
                CreatePool(item);
            }
        }

        private void CreatePool(PoolingItemSO item)
        {
            var pool = new Pool<IPoolable>(item.prefab, item.prefab.Type, transform, item.poolCount);
            _pools.Add(item.prefab.Type, pool);
        }

        public IPoolable Pop(PoolingType type)
        {
            if (_pools.ContainsKey(type) == false)
            {
                Debug.LogError($"Prefab does not exist on pool : {type.ToString()}");
                return null;
            }

            IPoolable item = _pools[type].Pop();
            item.ResetItem();
            return item;
        }

        public void Push(IPoolable obj, bool resetParent = false)
        {
            if (resetParent)
            {
                obj.PoolObject.transform.SetParent(transform);
            }
            _pools[obj.Type].Push(obj);
        }
    }
}
