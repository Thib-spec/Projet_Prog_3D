using DefaultNamespace;
using Unity.Mathematics;
using UnityEngine;

public class Key2Controller : MonoBehaviour
{
    [SerializeField] private Stats player;
    [SerializeField] private Transform keyTransform;
    private float y;

    void Awake()
    {
        player.OwnKey2 = false;
    }
    
    void Update()
    {
        y -= Time.deltaTime;
        keyTransform.rotation = quaternion.Euler(0,y,0);
    }

}
