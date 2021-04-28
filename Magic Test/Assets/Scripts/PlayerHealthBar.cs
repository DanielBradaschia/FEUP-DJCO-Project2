using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{

    public Slider slider;

    public Color color;

    public void SetHealth(float health, float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = health;
    }
    
}
