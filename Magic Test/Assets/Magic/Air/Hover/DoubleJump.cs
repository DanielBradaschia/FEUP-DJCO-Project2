using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : Magic
{
    public float cooldown = 2f;


    PlayerMovement characterMovement;
    bool isLearned = false;
    bool isSelected = false;

    public override void Activate()
    {
        characterMovement = GameObject.FindObjectOfType<PlayerMovement>();
        characterMovement.HandleDoubleJump();
    }

    public override float GetCooldown()
    {
        return cooldown;
    }

    public override bool getLearned()
    {
        return isLearned;
    }

    public override bool getSelected()
    {
        return isSelected;
    }

    public override void setSelected(bool select)
    {
        isSelected = select;
    }
}
