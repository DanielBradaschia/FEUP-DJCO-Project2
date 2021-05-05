using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    public float damage = 0.2f;

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Dummy>().Dmg(damage);
        }
    }
}
