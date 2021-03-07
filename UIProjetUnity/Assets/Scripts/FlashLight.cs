using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DefaultNamespace;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class FlashLight : MonoBehaviour
{
    private bool isOn=true;
    [SerializeField] private GameObject light;
    private bool hasBeenActivate;
    private WaitForSeconds wait = new WaitForSeconds(0.25f);
    [SerializeField] private StatManager batterybar;
    [SerializeField] private Stats battery;

    //private float currentBattery;
    private float maxBattery = 100;

    public void Start()
    {
        battery.Battery = maxBattery;
        batterybar.SetMaxBar(maxBattery);
        light.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (light.activeSelf && battery.Battery > 0)
        {
            DecreaseBattery();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isOn && !hasBeenActivate && battery.Battery>0f)
            {
                hasBeenActivate = true;
                light.SetActive(true);
                isOn = true;
                StartCoroutine(CheckLight());
                
            }
            if(!isOn && !hasBeenActivate)
            {
                hasBeenActivate = true;
                light.SetActive(false);
                isOn = false;
                StartCoroutine(CheckLight());
            }
        }

        if (isOn && battery.Battery <= 0f)
        {
            light.SetActive(false);
        }
    }

    private IEnumerator CheckLight()
    {
        yield return wait;
        hasBeenActivate = false;
    }

    public void DecreaseBattery()
    {
        battery.Battery -= Time.deltaTime*10f;
        batterybar.SetBar(battery.Battery);

    }
    
}
