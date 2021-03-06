using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHealController : Magic
{
    public float cooldown = 15f;

    GameObject player;
    [SerializeField]
    bool isLearned = true;
    [SerializeField]
    bool isSelected = false;

    public override void Activate()
    {
        player = GameObject.Find("Player");

        Instantiate(gameObject, player.transform.position, Quaternion.Euler(0f, 0f, 0f), player.transform);

        CharacterBehaviour ch = player.GetComponent<CharacterBehaviour>();
        ch.Heal(20f);
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
