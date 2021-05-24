using UnityEngine;

public class WallController : Magic
{
    public float cooldown = 7f;
    
    bool isLearned = true;

    public override void Activate()
    {
        GameObject camera = GameObject.Find("Camera");

        Transform cam = camera.transform;
        

        Ray rayOrigin = new Ray(camera.transform.position, camera.transform.forward);
        
        RaycastHit hit;
        if(Physics.Raycast(rayOrigin, out hit))
        {
            if (hit.collider != null && hit.collider.gameObject.layer == 8)
                Instantiate(gameObject, hit.point, Quaternion.Euler(0f, cam.eulerAngles.y, 0f));
        }


    }

    public override float GetCooldown()
    {
        return cooldown;
    }

    public override bool getLearned()
    {
        return isLearned;
    }
}
