using UnityEngine;

public class MagicController : MonoBehaviour
{
    public CharacterBehaviour Player;
    public ThirdPersonMovement characterMovement;
    public GameObject Fireball;
    public Transform cam;
    public float fireBallCooldown = 5f;
    public float waterHealCooldown = 10f;

    float activeElement = 1f;
    float fbCooldown;
    float whCooldown;

    void Start()
    {
        fbCooldown = fireBallCooldown;
        whCooldown = waterHealCooldown;
        characterMovement = GameObject.FindObjectOfType<ThirdPersonMovement>();
    }

    void Update()
    {
        fbCooldown -= Time.deltaTime;
        whCooldown -= Time.deltaTime;

        //Fireball
        if (Input.GetKeyDown(KeyCode.Q) && fbCooldown <= 0f)
        {
            fbCooldown = fireBallCooldown;

            Vector3 offset = transform.forward;
            
            GameObject fireball = Instantiate(Fireball, transform.position + offset, Quaternion.Euler(0f, cam.eulerAngles.y, 0f));
            
        }
        //Water Heal
        if (Input.GetKeyDown(KeyCode.F) && whCooldown <= 0f)
        {
            Player.Heal(20f);
        }


        if (Input.GetKeyDown(KeyCode.G))
        {
            characterMovement.HandleDash();
        }
        
    }
}
