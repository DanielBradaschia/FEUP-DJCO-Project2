using UnityEngine;

public class WallController : Magic
{
    public float cooldown = 7f;
    
    bool isLearned = true;
    [SerializeField]
    bool isSelected = true;

    public override void Activate()
    {
        GameObject camera = GameObject.Find("Camera");

        Transform cam = camera.transform;
        

        Ray rayOrigin = new Ray(camera.transform.position, camera.transform.forward);
        
        RaycastHit hit;
        if(Physics.Raycast(rayOrigin, out hit))
        {
            if (hit.collider != null && hit.collider.gameObject.layer == 8)
            {
                MeshRenderer mr = hit.collider.gameObject.GetComponent<MeshRenderer>();
                Material mat = mr.material;

                GameObject wallClone = Instantiate(gameObject, hit.point, Quaternion.Euler(0f, cam.eulerAngles.y, 0f));

                MeshRenderer[] children = wallClone.GetComponentsInChildren<MeshRenderer>();

                foreach (MeshRenderer mesh in children)
                {
                    mesh.material = mat;
                }
            }
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
