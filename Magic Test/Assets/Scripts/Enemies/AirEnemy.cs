using UnityEngine;

public class AirEnemy : AbstractEnemy
{
    public GameObject eye;
    public Transform FirePoint;
    public GameObject bullet;

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
    [SerializeField]
    float projectileSpeed = 20f;

    int randomSpot;
    float attackTimer;
    LayerMask whatIsPlayer;
    GameObject player;
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
            state = 1;
            Patrol();
        }
    }

    void Attack()
    {
        eye.transform.LookAt(player.transform);
        
        float speed = 5f;
        
        Vector3 targetDirection = player.transform.position - gameObject.transform.position;
        targetDirection += new Vector3(0f, 1.5f, 0f);
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(new Vector3(newDirection.x, newDirection.y, newDirection.z));

        if (attackTimer <= 0)
        {
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = FirePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(eye.transform.rotation.x, gameObject.transform.rotation.y, 0f);

            bulletClone.GetComponent<Rigidbody>().velocity = FirePoint.forward * projectileSpeed;


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
