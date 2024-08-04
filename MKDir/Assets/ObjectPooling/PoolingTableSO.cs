using System.Collections.Generic;
using UnityEngine;

namespace MKDir.ObjectPooling
{
    //! Test
    [CreateAssetMenu(menuName = "SO/PoolTable")]
    public class PoolingTableSO : ScriptableObject
    {
        public List<PoolingItemSO> poolDatas = new List<PoolingItemSO>();
    }
}
