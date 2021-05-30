using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Rigidbody rigid;

    public float delay = 5f;
    public float speed = 10f;
    public float radius = 2f;
    public float force = 200f;

    public GameObject explosion;

    public float hitDamage = 50f;
    public float explosionDamage = 35f;

    float countdown;
    bool hasExploded = false;

    void Start()
    {
        rigid.velocity = transform.forward * speed;

        countdown = delay;
    }
    
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            hasExploded = true;
            Explode();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.tag == "Enemy")
        {
            obj.GetComponent<AbstractEnemy>().TakeDamage(hitDamage);
        }
        else if (obj.tag == "EnemyPart")
        {
            obj.transform.parent.gameObject.GetComponent<AbstractEnemy>().TakeDamage(hitDamage);
        }
        hasExploded = true;
        Explode();
    }

    void Explode()
    {
        Instantiate(explosion, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObj in colliders)
        {
            if (nearbyObj.gameObject.tag == "Enemy")
            {
                nearbyObj.gameObject.GetComponent<Dummy>().Dmg(explosionDamage);
            }
            else if (nearbyObj.gameObject.tag == "EnemyPart")
            {
                nearbyObj.gameObject.transform.parent.gameObject.GetComponent<AbstractEnemy>().TakeDamage(hitDamage);
            }

            Rigidbody rb = nearbyObj.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        
        Destroy(gameObject);
    }
}
