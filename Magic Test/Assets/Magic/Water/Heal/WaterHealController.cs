using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHealController : Magic
{

    GameObject player;

    public float cooldown = 15f;

    public override void Activate()
    {
        Debug.Log("Water activate");
        player = GameObject.Find("Player");

        Instantiate(gameObject, player.transform.position, Quaternion.Euler(0f, 0f, 0f), player.transform);

        CharacterBehaviour ch = player.GetComponent<CharacterBehaviour>();
        ch.Heal(20f);
    }

    public override float GetCooldown()
    {
        return cooldown;
    }
}
