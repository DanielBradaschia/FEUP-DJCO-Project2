using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AirBoss : MonoBehaviour
{

    public GameObject tornado;
    public float speed = 1f;

   // public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;
    public float timeBetweenAttacks, attackRange;  
    public bool alreadyAttacked, playerInAttackRange;
    private Rigidbody instTornado;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Main Character Idle").transform;
     //   agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInAttackRange) AttackPlayer();
    }

    private void AttackPlayer()
    {
      //  agent.SetDestination(transform.position);

        transform.LookAt(player);
        if (!alreadyAttacked)
        {
            instTornado = Instantiate(tornado, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //  instTornadoRigidbody.AddForce(-speed, 0, 0, ForceMode.Impulse);
            instTornado.AddForce(transform.forward * 500f, ForceMode.Impulse);
            alreadyAttacked = true;

            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            instTornado.AddForce(transform.forward * 500f, ForceMode.Impulse);

        }
    }

    private void ResetAttack() {
        alreadyAttacked = false;
        Destroy(instTornado);

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) Invoke(nameof(DestroyBoss), -5f); 
    }

    private void DestroyBoss()
    {
        Destroy(gameObject);
    }
}
