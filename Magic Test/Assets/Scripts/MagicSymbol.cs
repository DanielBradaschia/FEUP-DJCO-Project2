using UnityEngine;
using UnityEngine.UI;

public class MagicSymbol : MonoBehaviour
{

    public Image symbol;

    Color grayScale = new Color(0.6f, 0.6f, 0.6f, 1f);
    Color normalScale = new Color(1f, 1f, 1f, 1f);

    float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if(cooldown <= 0)
            symbol.color = normalScale;
    }

    public void StartCooldown(float cooldown)
    {
        this.cooldown = cooldown;
        symbol.color = grayScale;

    }
}
