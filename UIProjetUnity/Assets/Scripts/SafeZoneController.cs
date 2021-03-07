using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class SafeZoneController : MonoBehaviour
{
    [SerializeField] private Stats health;
    public StatManager healthbar;

    private void OnTriggerStay(Collider other)
    {
        if (health.Health < 100)
        {
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
        healthbar.SetBar(health.Health);  // actualisation de l'UI (barre verte)
    }
}
