using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    [SerializeField] private List<PoolData> _data;

    private static PoolManager _instance = null;
    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("Pool").GetComponent<PoolManager>();
            }
            return _instance;
        }
    }

    private GameObject _Item;

    private Dictionary<string, Pool<PoolAble>> _pools = new Dictionary<string, Pool<PoolAble>>();


    private void Awake()
    {
        for (int i = 0; i < _data.Count; i++)
        {
            foreach (PoolAble p in _data[i].prefabs)
            {
                CreatePool(p, 3);
            }
        }

    }

    public void CreatePool(PoolAble prefab, int cnt = 5)
    {
        Pool<PoolAble> pool = new Pool<PoolAble>(prefab, transform, cnt);
        _pools.Add(prefab.gameObject.name, pool);
    }

    public PoolAble Pop(string prefabName)
    {
        if (_pools.ContainsKey(prefabName) == false)
        {
            Debug.LogError("프리펩없데");
            return null;
        }


        PoolAble item = _pools[prefabName].Pop();
        item.Reset();
        return item;
    }
    
    public PoolAble Pop(PoolAble prefab)
    {
        if (_pools.ContainsKey(prefab.name) == false)
        {
            Debug.LogWarning("프리펩이 없음 임시로 생성");
            _pools.Add(prefab.name, new Pool<PoolAble>(prefab, transform));
        }


        PoolAble item = _pools[prefab.name].Pop();
        item.Reset();
        return item;
    }


    public void Push(PoolAble obj)
    {
        obj.transform.SetParent(this.transform);
        _pools[obj.name].Push(obj);
    }
    public void RemovePool(string prefabName)
    {
        if (_pools.ContainsKey(prefabName))
        {
            _pools.Remove(prefabName);
        }
        else
        {
            Debug.LogError("프리펩없데..");
        }
        
        for(int i =0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).gameObject.name == prefabName)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}