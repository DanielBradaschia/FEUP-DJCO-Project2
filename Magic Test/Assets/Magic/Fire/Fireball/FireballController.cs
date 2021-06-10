using UnityEngine;

public class FireballController : Magic
{
    public float cooldown = 5f;
    
    bool isLearned = true;
    bool isSelected = true;

    public override void Activate()
    {
        GameObject camera = GameObject.Find("Camera");

        GameObject player = GameObject.Find("Player");
        
        Vector3 pos = player.transform.position + player.transform.forward;

        
        Ray rayOrigin = new Ray(camera.transform.position, camera.transform.forward);

        Vector3 aimPoint;
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, out hit))
        {
            if (hit.collider != null)
            {
                aimPoint = hit.point;
                Vector3 direction = aimPoint - pos;
                Instantiate(gameObject, pos, Quaternion.LookRotation(direction));
            }
        }
        else
        {
            aimPoint = rayOrigin.origin + rayOrigin.direction * 1000f;
            Vector3 direction = aimPoint - pos;
            Instantiate(gameObject, pos, Quaternion.LookRotation(direction));
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

    public override bool getSelected()
    {
        return isSelected;
    }

    public override void setSelected(bool select)
    {
        isSelected = select;
    }
}
