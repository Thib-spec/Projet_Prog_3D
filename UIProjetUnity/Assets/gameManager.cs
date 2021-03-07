using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    private bool key1;
    private void Awake()
    {
        //Cursor.SetCursor(cursorTexture,hotSpot,cursor);   
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.numberCandlesEnabled == 0 && !key1)
        {
            Instantiate(Resources.Load("key1"), new Vector3(-0.71f, 0.62f, 3.17f), Quaternion.identity).name="key1";
            key1 = true;
        }
        
    }
}
