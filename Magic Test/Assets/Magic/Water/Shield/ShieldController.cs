using UnityEngine;

public class ShieldController : Magic
{
    [SerializeField]
    float timeActive = 5f;
    [SerializeField]
    float cooldown = 10f;

    bool isActive = false;
    GameObject player;
    CharacterBehaviour ch;
    [SerializeField]
    bool isLearned = true;
    [SerializeField]
    bool isSelected = true;


    void Update()
    {
        if (isActive)
            timeActive -= Time.deltaTime;

        if (timeActive <= 0)
        {
            ch.SetShield(false);
            isActive = false;
            timeActive = 5f;
        }
    }

    public override void Activate()
    {
        player = GameObject.Find("Player");
        ch = player.GetComponent<CharacterBehaviour>();
        Vector3 offset = new Vector3(0f, 1.7f, 0f);
        
        GameObject clone = Instantiate(gameObject, player.transform, true);
        clone.transform.position = (player.transform.position + offset);
        isActive = true;
        ch.SetShield(true);
        Destroy(clone, 5f);
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
