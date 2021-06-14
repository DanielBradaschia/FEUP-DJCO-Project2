using UnityEngine;
using UnityEngine.UI;

public class MagicSymbol : MonoBehaviour
{
    public Image symbol;
    public Image fade;

    float cooldown;
    float fill;
    
    
    void Update()
    {
        fill += Time.deltaTime/cooldown;

        symbol.fillAmount = fill;
    }

    public void StartCooldown(float cooldown)
    {
        fill = 0;
        this.cooldown = cooldown;
        symbol.fillAmount = 0;
    }

    public void SetSymbol(Sprite s)
    {
        symbol.sprite = s;
        fade.sprite = s;
    }
}
