using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public CursorMode cursor = CursorMode.Auto;
    public Texture2D cursorTexture;
    public Vector2 hotSpot =Vector2.zero;
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
        
    }
}
