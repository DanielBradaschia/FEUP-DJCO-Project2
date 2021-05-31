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
    [SerializeField]
    float speed = 3f;
    [SerializeField]
    Transform[] moveSpots;

    int randomSpot;
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
        randomSpot = 0;
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
            if(state == 2)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                head.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
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
        Vector3 targetDirection = moveSpots[randomSpot].position - transform.position;
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(new Vector3(newDirection.x, 0, newDirection.z));

        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (randomSpot < moveSpots.Length - 1)
                randomSpot++;
            else
                randomSpot = 0;
        }
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
