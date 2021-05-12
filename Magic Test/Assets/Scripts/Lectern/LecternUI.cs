using UnityEngine;
using TMPro;

public class LecternUI : MonoBehaviour
{
    public GameObject lectern;
    public Vector3 offset;
    
    void Update()
    {
        gameObject.transform.position = Camera.main.WorldToScreenPoint(lectern.transform.position + offset);
    }
}
