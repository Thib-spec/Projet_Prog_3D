using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class SafeZoneController : MonoBehaviour
{
    [SerializeField] private Stats health;
    public StatManager healthbar;
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
        if (health.Health < 100)
        {
            Debug.Log("Regen");
            RegenHealth();   
        }
    }

    private void RegenHealth()
    {
        health.Health += Time.deltaTime * 2;
        if (health.Health > 100)
        {
            health.Health = 100;
        }
        healthbar.SetBar(health.Health);
    }
}
