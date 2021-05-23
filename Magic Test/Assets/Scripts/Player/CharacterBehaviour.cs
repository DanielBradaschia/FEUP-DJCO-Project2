using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public float maxHealth = 100f;
    public PlayerHealthBar phb;
    public GameObject ambient;


    float hp;

    bool healing;
    float healingAmount;

    void Start()
    {
        hp = maxHealth;
        phb.SetHealth(hp, maxHealth);
        healing = false;
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


        if (Input.GetKeyDown(KeyCode.L))
            ambient.SetActive(false);
        if (Input.GetKeyUp(KeyCode.L))
            ambient.SetActive(true);




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
        healing = true;
        healingAmount = value;
        
    }
}
