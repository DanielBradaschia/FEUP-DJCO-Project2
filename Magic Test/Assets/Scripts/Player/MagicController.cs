using UnityEngine;
using UnityEngine.UI;

public class MagicController : MonoBehaviour
{
    public CharacterBehaviour Player;
    public ThirdPersonMovement characterMovement;

    public GameObject Fireball;
    public GameObject Earthwall;

    public Transform cam;
    
    GameObject earthwall;
    float freezeTimer = 0.5f;

    public float fireBallCooldown = 5f;
    public float waterHealCooldown = 10f;
    public float earthWallCooldown = 5f;
    public float airDashCooldown = 5f;

    float activeElement = 1f;
    float fbCooldown;
    float whCooldown;
    float ewCooldown;
    float adCooldown;

    public GameObject MagicSymbols;

    MagicSymbol[] symbolsImage;

    void Start()
    {
        fbCooldown = 0f;
        whCooldown = 0f;
        ewCooldown = 0f;
        adCooldown = 0f;
        characterMovement = GameObject.FindObjectOfType<ThirdPersonMovement>();

        symbolsImage = MagicSymbols.GetComponentsInChildren<MagicSymbol>();

        
    }

    void Update()
    {
        fbCooldown -= Time.deltaTime;
        whCooldown -= Time.deltaTime;
        adCooldown -= Time.deltaTime;

        //Fireball
        if (Input.GetKeyDown(KeyCode.Q) && fbCooldown <= 0f)
        {
            symbolsImage[1].StartCooldown(fireBallCooldown);

            fbCooldown = fireBallCooldown;

            Vector3 offset = transform.forward;
            
            GameObject fireball = Instantiate(Fireball, transform.position + offset, Quaternion.Euler(0f, cam.eulerAngles.y, 0f));
            
        }
        //Water Heal
        if (Input.GetKeyDown(KeyCode.F) && whCooldown <= 0f)
        {
            symbolsImage[3].StartCooldown(waterHealCooldown);

            whCooldown = waterHealCooldown;
            Player.Heal(20f);
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && adCooldown <= 0f)
        {
            symbolsImage[0].StartCooldown(airDashCooldown);

            adCooldown = airDashCooldown;
            characterMovement.HandleDash();
        }

        //Raise Wall
        EarthwallRaise();
    }

    void EarthwallRaise()
    {
        ewCooldown -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.E) && ewCooldown <= 0f)
        {
            symbolsImage[2].StartCooldown(earthWallCooldown);

            Vector3 offset = cam.forward * 5;
            offset.y=0;
            GetComponent<ThirdPersonMovement>().enabled = false;
            Earthwall.transform.localScale = new Vector3(1, 0.01f, 1);
            earthwall = Instantiate(Earthwall, new Vector3(transform.position.x, 0.005f, transform.position.z) + offset, Quaternion.Euler(0f, cam.eulerAngles.y, 0f));
            freezeTimer = 0.5f;
            ewCooldown = earthWallCooldown;
        }

        if(earthwall && earthwall.transform.localScale.y < 1)
        {
            earthwall.transform.localScale += new Vector3(0, 0.01f, 0);
        }

        if(freezeTimer > 0) freezeTimer -= Time.deltaTime;
        if(!GetComponent<ThirdPersonMovement>().enabled && freezeTimer < 0)
        {
            GetComponent<ThirdPersonMovement>().enabled = true;
        }
    }
}
