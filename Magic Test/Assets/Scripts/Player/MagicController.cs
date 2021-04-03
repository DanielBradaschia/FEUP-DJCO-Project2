using UnityEngine;

public class MagicController : MonoBehaviour
{
    public GameObject Fireball;
    public Transform cam;

    float activeElement = 1f;

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 offset = transform.forward;
            
            GameObject fireball = Instantiate(Fireball, transform.position + offset, Quaternion.Euler(0f, cam.eulerAngles.y, 0f));
            
        }
    }
}
