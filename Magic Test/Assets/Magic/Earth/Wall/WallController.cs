using UnityEngine;

public class WallController : Magic
{
    public float cooldown = 7f;

    Transform cam;
    GameObject player;
    bool isLearned = true;

    public override void Activate()
    {
        cam = GameObject.Find("Camera").transform;
        player = GameObject.Find("Player");

        Vector3 offset = cam.forward * 5;
        offset.y = 0;
        Instantiate(gameObject, new Vector3(player.transform.position.x, 0.005f, player.transform.position.z) + offset, Quaternion.Euler(0f, cam.eulerAngles.y, 0f));
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
