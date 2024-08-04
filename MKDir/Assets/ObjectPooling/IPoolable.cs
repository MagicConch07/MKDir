using UnityEngine;

namespace MKDir.ObjectPooling
{
    public interface IPoolable
    {
        public PoolingType Type { get; }
        public GameObject PoolObject { get; }
        public void ResetItem();
    }
}
