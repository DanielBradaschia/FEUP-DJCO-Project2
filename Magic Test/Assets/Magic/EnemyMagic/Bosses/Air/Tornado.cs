using UnityEngine;
using System.Collections.Generic;

public class Tornado : MonoBehaviour
{

    public float delay = 2.5f;
    public float speed = 10f;
    public float radius = 2f;
    public float force = 200f;
    public GameObject player;

    float countdown;
    bool hasExploded = false;

    void Start()
    {
        countdown = delay;
        //player = GameObject.Find("Main Character Idle");
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            hasExploded = true;
            Explode();
        }
    }

    void OnParticleCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject == player)
            gameObject.SetActive(false);    // deactivate instead of destroy so you could later reactivate (respawn) him
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, ~0 , QueryTriggerInteraction.Collide);

        foreach (Collider nearbyObj in colliders)
        {
            //Rigidbody rb = nearbyObj.GetComponent<Rigidbody>();
            if (nearbyObj.tag == "Player")
            {
                Debug.Log("player");
                player.GetComponent<CharacterBehaviour>().TakeDamage(20f);
            }
        }

        gameObject.SetActive(false);
    }
}
