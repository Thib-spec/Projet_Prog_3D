using DefaultNamespace;
using Unity.Mathematics;
using UnityEngine;

public class Key1Controller : MonoBehaviour
{
    [SerializeField] private Stats player;
    [SerializeField] private Transform keyTransform;
    private float y;

    void Awake()
    {
        player.OwnKey1 = false;
    }
    
    void Update()
    {
        y += Time.deltaTime;
        keyTransform.rotation = quaternion.Euler(0,y,0);
    }

}
