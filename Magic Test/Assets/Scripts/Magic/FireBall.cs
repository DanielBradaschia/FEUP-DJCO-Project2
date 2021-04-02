using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Rigidbody rigid;

    public float maxDistance = 60f;
    public float speed = 10f;

    Vector3 initPosition;

    void Start()
    {
        rigid.velocity = transform.forward * speed;

        initPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(initPosition, transform.position) >= 30f)
        {
            Explode();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    void Explode()
    {
        Debug.Log("EXPLOSION");
        Destroy(gameObject);
    }
}
