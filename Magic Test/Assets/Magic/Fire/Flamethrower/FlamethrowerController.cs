using UnityEngine;

public class FlamethrowerController : Magic
{
    public float cooldown = 20f;
    public float damage = 0.2f;
    
    bool isLearned = false;
    bool isSelected = false;

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
                GameObject flame = Instantiate(gameObject, pos, Quaternion.LookRotation(direction), player.transform);
                Destroy(flame, 5f);
            }
        }
        else
        {
            aimPoint = rayOrigin.origin + rayOrigin.direction * 1000f;
            Vector3 direction = aimPoint - pos;
            GameObject flame = Instantiate(gameObject, pos, Quaternion.LookRotation(direction), player.transform);
            Destroy(flame, 5f);
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
