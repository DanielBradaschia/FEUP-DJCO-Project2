using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterBehaviour : MonoBehaviour
{
    public float maxHealth = 100f;
    public PlayerHealthBar phb;
    [SerializeField]
    Animator animator;
    [SerializeField]
    PlayerMovement pm;
    [SerializeField]
    MagicController mc;

    float hp;

    bool healing;
    float healingAmount;
    bool isShielded;

    float deathCounter = 5f;
    bool isDead;

    void Start()
    {
        hp = maxHealth;
        phb.SetHealth(hp, maxHealth);
        healing = false;
        isShielded = false;
        isDead = false;
    }
    
    void Update()
    {
        if(isDead)
        {
            deathCounter -= Time.deltaTime;
        }
        if (hp <= 0)
        {
            animator.SetBool("Death", true);
            //Things that make him be dead
            pm.enabled = false;
            mc.enabled = false;
            isDead = true;
            if(deathCounter <= 0)
                SceneManager.LoadScene(1);
        }

        if (healing)
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
