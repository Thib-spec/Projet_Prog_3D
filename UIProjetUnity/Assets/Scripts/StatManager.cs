using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    
    public void SetBar(float value)
    {
        slider.value = value;
        fill.color = gradient.Evaluate(slider.normalizedValue);     // Permet d'avoir un dégradé de couleur pour la barre de vie
        if (Math.Abs(slider.value - slider.minValue) == 0)
        {
            fill.enabled = false;                                    // Nos barres étant des sliders on désactive le fill pour éviter que la barre contienne un reste de couleur une fois vide
        }
        else
        {
            fill.enabled = true;
        }
    }
    
    public void SetMaxBar(float maxValue)
    {
        slider.maxValue = maxValue;
        slider.value = maxValue;
    }
}
