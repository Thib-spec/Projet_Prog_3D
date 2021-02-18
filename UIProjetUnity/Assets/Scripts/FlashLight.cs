using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class FlashLight : MonoBehaviour
{
    private bool isOn = false;
    [SerializeField] private GameObject light;
    private bool hasBeenActivate = false;
    private WaitForSeconds wait = new WaitForSeconds(0.25f);
    [SerializeField] private BatteryBar batterybar;

    private float currentBattery;
    private float maxBattery = 100;

    public void Start()
    {
        currentBattery = maxBattery;
        batterybar.SetMaxBatteryBar(maxBattery);
        light.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (light.activeSelf && currentBattery > 0)
        {
            DecreaseBattery();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isOn && !hasBeenActivate)
            {
                hasBeenActivate = true;
                light.SetActive(true);
                isOn = true;
                StartCoroutine(CheckLight());
                
            }
            if(isOn && !hasBeenActivate)
            {
                hasBeenActivate = true;
                light.SetActive(false);
                isOn = false;
                StartCoroutine(CheckLight());
            }
        }
    }

    private IEnumerator CheckLight()
    {
        yield return wait;
        hasBeenActivate = false;
    }

    public void DecreaseBattery()
    {
        currentBattery -= Time.deltaTime;
        batterybar.SetBatteryBar(currentBattery);

    }
}
