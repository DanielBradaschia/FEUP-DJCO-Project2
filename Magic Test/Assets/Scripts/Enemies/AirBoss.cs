using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
    bool isDead = false;
    float deadTime = 5f;

    GameObject laughSound;
    GameObject dieSound;

    void Start()
    {
        anim = GetComponent<Animator>();
        laughSound = transform.Find("LaughSound").gameObject;
        dieSound = transform.Find("DieSound").gameObject;
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
        if (!isDead)
        {
            //playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
            playerInAttackRange = Vector3.Distance(player.position, transform.position) < attackRange;
            if (playerInAttackRange) AttackPlayer();
            if (health <= 1000) timeBetweenAttacks = 3;
            ToggleBarrier();
        } else { 
        
            deadTime -= Time.deltaTime;
            if(deadTime <= 0)
                SceneManager.LoadScene(1);
        }
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
        laughSound.SetActive(true);
        Invoke(nameof(StopLaughSound), 0.5f);
        health -= damage;
        if (health <= 0) Die(); 
    }

    public override void Die()
    {
        laughSound.SetActive(false);
        dieSound.SetActive(true);
        anim.SetBool("death", true);
        isDead = true;
    }

    private void StopLaughSound()
    {
        laughSound.SetActive(false);
    }
}
