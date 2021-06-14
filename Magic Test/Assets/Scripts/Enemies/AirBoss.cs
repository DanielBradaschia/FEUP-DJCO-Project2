using UnityEngine;
using UnityEngine.AI;

public class AirBoss : AbstractEnemy
{

    public GameObject tornado;

   // public NavMeshAgent agent;
    public float health;
    public float timeBetweenAttacks, attackRange;  
    Transform player;
    LayerMask whatIsPlayer;
    bool alreadyAttacked, playerInAttackRange;
    private Rigidbody instTornado;

    void Awake()
    {
        whatIsPlayer = 9;
        player = GameObject.Find("Player").transform;
     //   agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        //playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        playerInAttackRange = Vector3.Distance(player.position, transform.position) < attackRange;
        if (playerInAttackRange) AttackPlayer();
        if (health <= 1000) timeBetweenAttacks = 3;
    }

    private void AttackPlayer()
    {
      //  agent.SetDestination(transform.position);

        transform.LookAt(player);
        if (!alreadyAttacked)
        {
            instTornado = Instantiate(tornado, player.position, Quaternion.identity).GetComponent<Rigidbody>();
            //  instTornadoRigidbody.AddForce(-speed, 0, 0, ForceMode.Impulse);
            //instTornado.AddForce(transform.forward * 500f, ForceMode.Impulse);
            alreadyAttacked = true;

            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            //instTornado.AddForce(transform.forward * 500f, ForceMode.Impulse);

        }
    }

    private void ResetAttack() {
        alreadyAttacked = false;
        Destroy(instTornado);

    }

    public override void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) Invoke(nameof(Die), -5f); 
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
