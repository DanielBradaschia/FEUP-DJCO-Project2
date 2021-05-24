using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado_shooter : MonoBehaviour
{
    public GameObject tornado;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject instTornado = Instantiate(tornado, transform.position + new Vector3(0, 10, 0), Quaternion.identity) as GameObject;
            Rigidbody instTornadoRigidbody = instTornado.GetComponent<Rigidbody>();
            instTornadoRigidbody.AddForce(-speed, 0, 0, ForceMode.Impulse);
            instTornadoRigidbody.AddForce(Vector3.forward * speed);


        }
    }
}
