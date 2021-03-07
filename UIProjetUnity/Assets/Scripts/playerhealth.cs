using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour
{
    private static int maxHealth = 100;
    [SerializeField] private Stats health;

    public StatManager healthbar;
    void Start()
    {
        health.Health = maxHealth;              // Le joueur commence avec sa vie pleine
        healthbar.SetMaxBar(maxHealth);
    }
}
