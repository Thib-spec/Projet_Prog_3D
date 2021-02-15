using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour
{
    private int maxHealth = 100;

    private int currentHealth;

    public HealthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxhealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDammage(20);
        }
    }

    public void takeDammage(int dammage)
    {
        currentHealth -= dammage;
        healthbar.SetHealthBar(currentHealth);
    }
}
