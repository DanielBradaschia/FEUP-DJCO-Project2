using UnityEngine;

public abstract class Magic : MonoBehaviour
{
    public abstract void Activate();

    public abstract float GetCooldown();

    public abstract bool getLearned();
}
