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
        if (slider.value == slider.minValue)
        {
            fill.enabled = false;
        }
    }
    
}
