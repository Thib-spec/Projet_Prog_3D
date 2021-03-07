using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DefaultNamespace;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class FlashLight : MonoBehaviour
{
    private bool isOn;
    [SerializeField] private GameObject light;          // on référence notre source de lumière
    private bool hasBeenActivate;
    private WaitForSeconds wait = new WaitForSeconds(0.25f); // On instancie un nouveau WaitForSeconds pour éviter de l'instancier à chaque appel de la coroutine
    [SerializeField] private StatManager batterybar;
    [SerializeField] private Stats battery;

    //private float currentBattery;
    private static float maxBattery = 100;

    public void Start()
    {
        battery.Battery = maxBattery;               // par défaut on a le max de battery et la lampe torche est éteinte
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
            if (!isOn && !hasBeenActivate && battery.Battery>0f)        // isOn vérifie si la lampe est éteinte ou non
            {                                                           // hasBeenActivate agit comme une mémoire pour savoir si on est déjà rentré dans une des deux boucles if
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

        if (isOn && battery.Battery <= 0f)          // Dans le cas où notre batterie est vide on désactive la lampe torche
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
        battery.Battery -= Time.deltaTime*10f;      // On diminue la valeur de notre batterie
        batterybar.SetBar(battery.Battery);         // On actualise l'UI (barre jaune)

    }
    
}
