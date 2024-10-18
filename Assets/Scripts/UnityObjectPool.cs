using UnityEngine;
using UnityEngine.Pool;

public class UnityReturnToPool : MonoBehaviour
{
    public ObjectPool<GameObject> pool;
    private void OnDisable()
    {
        pool.Release(gameObject);
    }
}

public class UnityObjectPool : MonoBehaviour
{
    public static UnityObjectPool Instance;
    [SerializeField] private GameObject baseObject;
    private ObjectPool<GameObject> pool;
    private GameObject tmp;
    private UnityReturnToPool returnToPool;

    private void Awake()
    {
        Instance = this;
        pool = new ObjectPool<GameObject>(OnCreateItem, OnGetItem, OnReleaseItem, OnDestroyItem);
    }

    public GameObject GetObjectFromPool()
    {
        return pool.Get();
    }

    private GameObject OnCreateItem()
    {
        tmp = Instantiate(baseObject);
        returnToPool = tmp.AddComponent<UnityReturnToPool>();
        returnToPool.pool = pool;
        return tmp;
    }

    private void OnGetItem(GameObject obj)
    {
        obj.SetActive(true);
    }

    private void OnReleaseItem(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void OnDestroyItem(GameObject obj)
    {
        Destroy(obj);
    }
}