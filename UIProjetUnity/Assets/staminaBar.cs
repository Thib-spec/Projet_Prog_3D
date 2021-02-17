using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staminaBar : MonoBehaviour
{
    
    public Slider slider;
    [SerializeField] private Image fill;
    [SerializeField] private Gradient gradient;
   
    public void SetStaminaBar(float stamina)
    {
        slider.value = stamina;
        if (slider.value == slider.minValue)
        {
            fill.enabled = false;
        }
    }

    public void SetMaxStamina(int maxStamina)
    {
        slider.maxValue = maxStamina;
        slider.value = maxStamina;
    }
}
