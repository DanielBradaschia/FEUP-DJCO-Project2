using UnityEngine;

public class AirEnemy : AbstractEnemy
{
    public GameObject head;


    [SerializeField]
    float health = 3000f;
    [SerializeField]
    float attackRange = 15f;
    [SerializeField]
    float attackCooldown = 5f;

    float attackTimer;

    LayerMask whatIsPlayer;
    GameObject player;
    /**
     *  1- Patrol 
     *  2- Attack
     */
    int state;


    void Start()
    {
        attackTimer = attackCooldown;
        whatIsPlayer = 9;
        player = GameObject.Find("Player");
    }


    void Update()
    {
        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        

        if(Vector3.Distance(gameObject.transform.position, player.transform.position) <= attackRange)
        {
            if(state == 1)
            {
                attackTimer = attackCooldown;
            }
            state = 2;
            Attack();
        }
        else
        {
            state = 1;
            Patrol();
        }
    }

    void Attack()
    {
        head.transform.LookAt(player.transform);

        float speed = 5f;
        
        Vector3 targetDirection = player.transform.position - gameObject.transform.position;
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(new Vector3(newDirection.x, 0, newDirection.z));

        if (attackTimer <= 0)
        {
            //Shoot projectile
            Debug.Log("Shoot");
            attackTimer = attackCooldown;
        }
    }

    void Patrol()
    {
        //Patrol between 2 points
    }





    public override void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    public override void Die()
    {
        //Fazer cenas para morrer
        Destroy(gameObject);
    }
}
