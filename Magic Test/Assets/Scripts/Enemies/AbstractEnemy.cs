using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour
{
    public abstract void TakeDamage(float damage);

    public abstract void Die();
}
