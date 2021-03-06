﻿using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    PooledObject prefab;
	public PooledObject GetObject()
    {
        PooledObject obj = Instantiate<PooledObject>(prefab);
        obj.transform.SetParent(transform, false);
        obj.Pool = this;
        return obj;
    }
	
	public void AddObject (PooledObject o)
    {
        Object.Destroy(o.gameObject);
    }

    public static ObjectPool GetPool (PooledObject prefab)
    {
        GameObject obj = new GameObject(prefab.name + " Pool");
        ObjectPool pool = obj.AddComponent<ObjectPool>();
        pool.prefab = prefab;
        return pool;
    }
}
