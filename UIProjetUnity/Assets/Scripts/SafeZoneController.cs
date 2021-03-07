using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class SafeZoneController : MonoBehaviour
{
    [SerializeField] private Stats health;
    public StatManager healthbar;

    private void OnTriggerStay(Collider other) // Lorsque le joueur est dans la zone
    {
        if (health.Health < 100) // Si la vie du joueur n'est pas pleine
        {
            RegenHealth();   // On soigne le joueur
        }
    }

    private void RegenHealth() // Fonction de soin
    {
        health.Health += Time.deltaTime * 2; // Augmentation de la vie
        if (health.Health > 100) // Si la vie dépasse 100
        {
            health.Health = 100; // On la définit manuellement à 100 pour éviter tout problème
        }
        healthbar.SetBar(health.Health);  // actualisation de l'UI (barre verte)
    }
}
