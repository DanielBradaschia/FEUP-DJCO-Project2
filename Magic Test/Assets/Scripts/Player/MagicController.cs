using UnityEngine;

public class MagicController : MonoBehaviour
{
    public GameObject Fireball;
    public Transform cam;
    public float fireBallCooldown = 5f;

    float activeElement = 1f;
    float fbCooldown;

    void Start()
    {
        fbCooldown = fireBallCooldown;
    }

    void Update()
    {
        fbCooldown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q) && fbCooldown <= 0f)
        {
            fbCooldown = fireBallCooldown;

            Vector3 offset = transform.forward;
            
            GameObject fireball = Instantiate(Fireball, transform.position + offset, Quaternion.Euler(0f, cam.eulerAngles.y, 0f));
            
        }
    }
}
