using UnityEngine;

public class ProtectionController : Magic
{
    public float cooldown = 12f;

    public GameObject player;

    PlayerMovement mov;
    CharacterBehaviour ch;
    GameObject clone;
    float timer = 5f;
    bool isLearned = false;
    bool isSelected = false;

    void Start()
    {
        mov = player.GetComponent<PlayerMovement>();

        ch = player.GetComponent<CharacterBehaviour>();
        ch.Heal(35f);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            mov.enabled = true;
            Destroy(gameObject);
        }
        else
        {
            mov.enabled = false;
        }
    }

    public override void Activate()
    {
        player = GameObject.Find("Player");
        PlayerMovement pm = player.GetComponent<PlayerMovement>();

        clone = Instantiate(gameObject, player.transform.position, Quaternion.Euler(0f, 0f, 0f), player.transform);
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
        isSelected = select;
    }
}
