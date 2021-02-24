using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private Button itemButton;
    private string identity;
    
    
    void Start()
    {
        inventoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("IN");
        if (Input.GetKeyDown(KeyCode.E))
        {
            other.GetComponent<Image>();
            itemButton.image= other.GetComponent<Image>();
        }
    }

}
