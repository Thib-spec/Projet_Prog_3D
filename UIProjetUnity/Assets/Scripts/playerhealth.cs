using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour
{
    private int maxHealth = 100;

    //private int currentHealth;
    [SerializeField] private Stats health;

    public StatManager healthbar;
    // Start is called before the first frame update
    void Start()
    {
        health.Health = maxHealth;
        healthbar.SetMaxBar(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(20);
        }
    }

    public void takeDamage(int damage)
    {
        health.Health -= damage;
        healthbar.SetBar(health.Health);
    }
}
