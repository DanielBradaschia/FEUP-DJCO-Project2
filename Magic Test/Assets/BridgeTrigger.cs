using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
    }    
}
