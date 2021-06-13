using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public float maxHealth = 100f;
    public PlayerHealthBar phb;


    float hp;

    bool healing;
    float healingAmount;
    bool isShielded;

    void Start()
    {
        hp = maxHealth;
        phb.SetHealth(hp, maxHealth);
        healing = false;
        isShielded = false;
    }
    
    void Update()
    {
        if(healing)
        {
            if ((hp + Time.deltaTime) < maxHealth && healingAmount > 0)
            {
                hp += 0.05f;
                healingAmount -= 0.05f;
            }
            else
                healing = false;

            phb.SetHealth(hp, maxHealth);
        }
        

    }

    public float getHp()
    {
        return hp;
    }

    public void TakeDamage(float value)
    {
        if (isShielded)
        {
            float v = value * 0.75f;
            hp -= v;
        }
        else
        {
            hp -= value;
        }

        phb.SetHealth(hp, maxHealth);
    }

    public void Heal(float value) 
    {
        healing = true;
        healingAmount = value;
        
    }

    public void SetShield(bool shield)
    {
        isShielded = shield;
    }

}
