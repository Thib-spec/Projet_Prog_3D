using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    private float energy = 30;
    [SerializeField] private Stats battery;
    [SerializeField] private StatManager batterybar;
    
    // Start is called before the first frame update
    void Start()
    
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Touch");
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
            BatteryCharge(energy);   
            
        }
    }
    
    private void BatteryCharge(float energy)
    {
        battery.Battery += energy;
        if (battery.Battery > 100)
        {
            battery.Battery = 100;
        }
        batterybar.SetBar(battery.Battery);
    }
}
