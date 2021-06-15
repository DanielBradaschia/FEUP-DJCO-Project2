using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dummy : AbstractEnemy
{
    float accumulatedDamage;

    float counter = 5f;

    public TMP_Text damageText;

    private void Start()
    {
        accumulatedDamage = 0f;
        damageText.text = "";
    }
    
    void Update()
    {
        counter -= Time.deltaTime;
        if(counter <= 0)
        {
            counter = 5f;
            accumulatedDamage = 0f;
            damageText.text = "";
        }
    }

    public void Dmg(float damage)
    {
        accumulatedDamage += damage;
        counter = 5f;
        damageText.text = accumulatedDamage.ToString();
    }

    public override void TakeDamage(float damage)
    {
        accumulatedDamage += damage;
        counter = 5f;
        damageText.text = accumulatedDamage.ToString();
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }
}
