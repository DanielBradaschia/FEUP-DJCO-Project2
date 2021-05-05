using UnityEngine;

public class FireballController : Magic
{
    Transform cam;
    GameObject player;

    public float cooldown = 5f;

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
}
