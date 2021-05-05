using UnityEngine;

public class Dummy : MonoBehaviour
{
    float maxHp = 9999999;
    float hp;

    float counter = 5f;

    private void Start()
    {
        hp = maxHp;
    }
    
    void Update()
    {
        counter -= Time.deltaTime;
        if(counter <= 0)
        {
            counter = 5f;
            Heal();
        }
    }

    

    public void Dmg(float damage)
    {
        Debug.Log("I'm taking " + damage + " damage");
    }

    void Heal()
    {
        hp = maxHp;
    }
}
