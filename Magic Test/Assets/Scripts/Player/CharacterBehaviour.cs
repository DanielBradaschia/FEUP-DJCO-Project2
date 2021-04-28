using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public float maxHealth = 100f;
    public PlayerHealthBar phb;

    float hp;
    
    void Start()
    {
        hp = maxHealth;
        phb.SetHealth(hp, maxHealth);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            TakeDamage(10f);
    }

    public float getHp()
    {
        return hp;
    }

    public void TakeDamage(float value)
    {
        hp -= value;
        
        phb.SetHealth(hp, maxHealth);
    }

    public void Heal(float value) 
    {
        if ((hp + value) < maxHealth)
            hp += value;
        else
            hp = maxHealth;

        phb.SetHealth(hp, maxHealth);
    }
}
