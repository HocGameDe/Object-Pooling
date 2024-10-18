using UnityEngine;

public class TestObject : MonoBehaviour
{
    private void OnEnable()
    {
        transform.position = UnityEngine.Random.insideUnitCircle * 20f;
    }
    private void Update()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}