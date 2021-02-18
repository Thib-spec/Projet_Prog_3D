using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staminaBar : MonoBehaviour
{
    
    public Slider slider;
    [SerializeField] private Image fill;

    public void SetStaminaBar(float stamina)
    {
        slider.value = stamina;
        if (Math.Abs(slider.value - slider.minValue) == 0)
        {
            fill.enabled = false;
        }
        else
        {
            fill.enabled = true;
        }
    }

    public void SetMaxStamina(float maxStamina)
    {
        slider.maxValue = maxStamina;
        slider.value = maxStamina;
    }
}
