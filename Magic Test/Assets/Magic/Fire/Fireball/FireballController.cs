using UnityEngine;

public class FireballController : Magic
{
    public float cooldown = 5f;

    Transform cam;
    GameObject player;
    bool isLearned = true;

    public override void Activate()
    {
        cam = GameObject.Find("Camera").transform;
        player = GameObject.Find("Player");

        Vector3 offset = player.transform.forward;

        Instantiate(gameObject, player.transform.position + offset, Quaternion.Euler(0f, cam.eulerAngles.y, 0f));
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
