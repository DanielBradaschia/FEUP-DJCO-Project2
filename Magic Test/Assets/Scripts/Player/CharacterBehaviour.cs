using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public float maxHealth = 100f;

    private float hp;
    
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHealth;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getHp()
    {
        return hp;
    }

    public void Heal(float value) 
    {
        if (hp < maxHealth)
            hp += value;
        //Debug.Log(hp);
    }
}
