using UnityEngine;

public class Dash : Magic
{
    public float cooldown = 3f;
    ThirdPersonMovement characterMovement;

    public override void Activate()
    {
        characterMovement = GameObject.FindObjectOfType<ThirdPersonMovement>();
        characterMovement.HandleDash();
    }

    public override float GetCooldown()
    {
        return cooldown;
    }
}
