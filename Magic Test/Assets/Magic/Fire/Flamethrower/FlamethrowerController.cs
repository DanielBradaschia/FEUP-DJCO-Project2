using UnityEngine;

public class FlamethrowerController : Magic
{
    public float cooldown = 20f;
    public float damage = 0.2f;
    [SerializeField]
    bool isLearned = false;
    [SerializeField]
    bool isSelected = false;

    public override void Activate()
    {
        GameObject camera = GameObject.Find("Camera");
        GameObject player = GameObject.Find("Player");
        Transform fp = player.transform.Find("FirePoint");

        Vector3 pos = player.transform.position + player.transform.forward;

        Ray rayOrigin = new Ray(camera.transform.position, camera.transform.forward);

        Vector3 aimPoint;
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, out hit))
        {
            if (hit.collider != null)
            {
                aimPoint = hit.point;
                Vector3 direction = aimPoint - fp.position;
                GameObject flame = Instantiate(gameObject, fp.position, Quaternion.LookRotation(direction), player.transform);
                Destroy(flame, 5f);
            }
        }
        else
        {
            aimPoint = rayOrigin.origin + rayOrigin.direction * 1000f;
            Vector3 direction = aimPoint - fp.position;
            GameObject flame = Instantiate(gameObject, fp.position, Quaternion.LookRotation(direction), player.transform);
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
        if (isLearned)
            isSelected = select;
    }

    public Sprite icon;
    public override Sprite getSprite()
    {
        return icon;
    }
}
