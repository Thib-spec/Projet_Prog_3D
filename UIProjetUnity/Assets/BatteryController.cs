using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    private float energy = 30;
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
            Debug.Log("Destroy");
            Destroy(this.gameObject);
        }
    }
}
