using UnityEngine;

public class FlamethrowerController : Magic
{
    public float cooldown = 20f;
    public float damage = 0.2f;

    Transform cam;
    GameObject player;
    bool isLearned = false;


    public override void Activate()
    {
        cam = GameObject.Find("Camera").transform;
        player = GameObject.Find("Player");

        Vector3 offset = new Vector3(0f, 0.5f, 1f);

        GameObject flame = Instantiate(gameObject, player.transform.position + offset, Quaternion.Euler(0f, cam.eulerAngles.y, 0f), player.transform);
        Destroy(flame, 5f);
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
