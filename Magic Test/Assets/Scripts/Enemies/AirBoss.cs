using UnityEngine;
using UnityEngine.AI;

public class AirBoss : AbstractEnemy
{
    Animator anim;
    public float attackDuration = 1f;

    public GameObject tornado;
    public GameObject barrier;

   // public NavMeshAgent agent;
    public float health;
    public float timeBetweenAttacks, attackRange;  
    Transform player;
    LayerMask whatIsPlayer;
    bool alreadyAttacked, playerInAttackRange;
    private Rigidbody instTornado;
    
    public float barrierCooldown = 10f;
    float barrierTimer;
    bool barrierUp = false;
    GameObject instBarrier;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Awake()
    {
        whatIsPlayer = 9;
        player = GameObject.Find("Player").transform;
        barrierTimer = 0;
     //   agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        //playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        playerInAttackRange = Vector3.Distance(player.position, transform.position) < attackRange;
        if (playerInAttackRange) AttackPlayer();
        if (health <= 1000) timeBetweenAttacks = 3;
        ToggleBarrier();
    }

    private void ToggleBarrier()
    {
        if(barrierUp && barrierTimer > 0)
        {
            barrierTimer -= Time.deltaTime*2;
        }
        else if(!barrierUp && barrierTimer < barrierCooldown)
        {
            barrierTimer += Time.deltaTime;
        }
        else if(barrierUp && barrierTimer <= 0)
        {
            BarrierDown();
        }
        else if(!barrierUp && barrierTimer >= barrierCooldown)
        {
            BarrierUp();
        }
    }

    private void AttackPlayer()
    {
      //  agent.SetDestination(transform.position);

        transform.LookAt(player);
        if (!alreadyAttacked)
        {
            anim.SetBool("attack", true);

            Invoke(nameof(Stop), attackDuration);

            InstatiateTornado();
        }
    }

    private void Stop()
    {
        Debug.Log("stop animation");
        anim.SetBool("attack", false);
    }

    private void ResetAttack() {
        alreadyAttacked = false;
        Destroy(instTornado);

    }

    private void InstatiateTornado()
    {
        instTornado = Instantiate(tornado, player.position, Quaternion.identity).GetComponent<Rigidbody>();
        //  instTornadoRigidbody.AddForce(-speed, 0, 0, ForceMode.Impulse);
        //instTornado.AddForce(transform.forward * 500f, ForceMode.Impulse);
        alreadyAttacked = true;

        Invoke(nameof(ResetAttack), timeBetweenAttacks);
        //instTornado.AddForce(transform.forward * 500f, ForceMode.Impulse);
    }

    private void BarrierUp() 
    {
        if(!barrierUp)
        {
            anim.SetBool("attack", true);
            Invoke(nameof(Stop), attackDuration);
            instBarrier = (GameObject) Instantiate(barrier, transform.position + new Vector3(0, 12, 0), Quaternion.identity);
            barrierUp = true;
        }
    }

    private void BarrierDown()
    {
        if(barrierUp && instBarrier)
        {
            Destroy(instBarrier);
            instBarrier = null;
            barrierUp = false;
        }
    } 

    public override void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) Die(); 
    }

    public override void Die()
    {
        anim.SetBool("death", true);
        GetComponent<AirBoss>().enabled = false;
    }
}
