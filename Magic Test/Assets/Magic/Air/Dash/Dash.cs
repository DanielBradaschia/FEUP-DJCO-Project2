using UnityEngine;

public class Dash : Magic
{
    public float cooldown = 3f;
    

    PlayerMovement characterMovement;
    [SerializeField]
    bool isLearned = true;
    [SerializeField]
    bool isSelected = true;

    public override void Activate()
    {
        characterMovement = GameObject.FindObjectOfType<PlayerMovement>();
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

    public override bool getSelected()
    {
        return isSelected;
    }

    public override void setSelected(bool select)
    {
        if (isLearned)
            isSelected = select;
    }

    public Sprite icon;
    public override Sprite getSprite()
    {
        return icon;
    }
}
