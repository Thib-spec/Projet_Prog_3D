using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Image fill;
    
    public void SetBatteryBar(float battery)
    {
        slider.value = battery;
        if (Math.Abs(slider.value - slider.minValue) == 0)
        {
            fill.enabled = false;
        }
        else
        {
            fill.enabled = true;
        }
    }
    
    public void SetMaxBatteryBar(float maxBattery)
    {
        slider.maxValue = maxBattery;
        slider.value = maxBattery;
    }
    
}
