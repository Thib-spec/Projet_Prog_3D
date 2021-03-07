using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    private bool key1;
    [SerializeField] private AudioClip keyClip;

    [SerializeField] private AudioSource source;
    // Update is called once per frame
    void Update()
    {
        if (PlayerController.NumberCandlesEnabled == 0 && !key1)
        {
            Instantiate(Resources.Load("key1"), new Vector3(-0.71f, 0.62f, 3.17f), Quaternion.identity).name="key1";
            key1 = true;
            source.PlayOneShot(keyClip);
        }
        
    }
}
