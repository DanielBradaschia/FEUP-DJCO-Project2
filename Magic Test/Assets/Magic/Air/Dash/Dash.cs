using UnityEngine;

public class Dash : Magic
{
    public float cooldown = 3f;
    

    ThirdPersonMovement characterMovement;
    bool isLearned = true;

    public override void Activate()
    {
        characterMovement = GameObject.FindObjectOfType<ThirdPersonMovement>();
        characterMovement.HandleDash();
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
