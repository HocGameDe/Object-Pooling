using UnityEngine;

public class TestPerformance : MonoBehaviour
{
    [SerializeField] private TestObject testObject;
    [SerializeField] private int amount = 2000;

    private void Update()
    {
        for (int i = 0; i < amount; i++)
        {
            //Instantiate(testObject);
            //UnityObjectPool.Instance.GetObjectFromPool();
            MyPoolManager.Instance.GetFromPool(testObject.gameObject);
        }
    }
}