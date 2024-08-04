using System.Collections;
using System.Collections.Generic;
using MKDir.ObjectPooling;
using UnityEngine;

public class Item : MonoBehaviour, IPoolable
{
    [field: SerializeField] public PoolingType Type { get; }

    public PoolingType type;

    public GameObject PoolObject => throw new System.NotImplementedException();

    public void ResetItem()
    {
        throw new System.NotImplementedException();
    }
}
