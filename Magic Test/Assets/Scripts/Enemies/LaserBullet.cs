using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    public int damage = 20;

    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.tag != "Enemy")
        {
            if (obj.tag == "Player")
            {
                CharacterBehaviour player = obj.GetComponent<CharacterBehaviour>();
                player.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
