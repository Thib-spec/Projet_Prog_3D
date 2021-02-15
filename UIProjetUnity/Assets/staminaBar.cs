using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staminaBar : MonoBehaviour
{
    
    public Slider slider;
    public Image fill;
    public Gradient gradient;
   
    public void SetStaminaBar(float stamina)
    {
        slider.value = stamina;
        fill.color = gradient.Evaluate(slider.value);
        if (slider.value == slider.minValue)
        {
            fill.enabled = false;
        }
    }

    public void SetMaxStamina(int maxStamina)
    {
        slider.maxValue = maxStamina;
        slider.value = maxStamina;
        fill.color = gradient.Evaluate(1);
    }
}
