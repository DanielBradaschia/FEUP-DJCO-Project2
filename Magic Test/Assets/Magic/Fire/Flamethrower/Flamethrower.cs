using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    public float damage = 0.2f;
    public GameObject flame;

    GameObject camera;
    Vector3 hit;
    Vector3 direction;

    void Start()
    {
        camera = GameObject.Find("Camera");
    }

    void Update()
    {
        Ray rayOrigin = new Ray(camera.transform.position, camera.transform.forward);

        Vector3 aimPoint;
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, out hit))
        {
            aimPoint = hit.point;
            
        }
        else
        {
            aimPoint = rayOrigin.origin + rayOrigin.direction * 1000f;
        }
        
        direction = aimPoint - transform.position;
        
        transform.rotation = Quaternion.LookRotation(direction);
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Dummy>().Dmg(damage);
        }
    }
}
