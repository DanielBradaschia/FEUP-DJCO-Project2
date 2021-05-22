using UnityEngine;

public class DummyDamageCounter : MonoBehaviour
{
    public Vector3 offset;
    public GameObject dummy;

    private void Update()
    {
        gameObject.transform.position = Camera.main.WorldToScreenPoint(dummy.transform.position + offset);
    }
}
