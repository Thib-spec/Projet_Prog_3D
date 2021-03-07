using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.Mathematics;
using UnityEngine;

public class Key2Controller : MonoBehaviour
{
    [SerializeField] private Stats player;
    [SerializeField] private Transform keyTransform;
    private float y;
    // Start is called before the first frame update
    void Awake()
    {
        player.OwnKey2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        y -= Time.deltaTime;
        keyTransform.rotation = quaternion.Euler(0,y,0);
    }

}
