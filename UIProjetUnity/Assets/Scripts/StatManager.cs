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
        fill.color = gradient.Evaluate(slider.normalizedValue);
        if (Math.Abs(slider.value - slider.minValue) == 0)
        {
            fill.enabled = false;
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
