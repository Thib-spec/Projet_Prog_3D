using DefaultNamespace;
using Unity.Mathematics;
using UnityEngine;

public class Key3Controller : MonoBehaviour
{
    [SerializeField] private Stats player;
    [SerializeField] private Transform keyTransform;
    private float y;
    [SerializeField] private Material col;

    private int colChange;

    void Awake()
    {
        player.OwnKey3 = false;
    }


    void Update()
    {
        y += Time.deltaTime;
        keyTransform.rotation = quaternion.Euler(0,y,0);
        if (colChange < 30)
        {
            col.color = Color.cyan;
        }
        else if (colChange < 60)
        {
            col.color = Color.magenta;
        }
        else
        {
            col.color = Color.green;
        }

        if (colChange >= 90)
        {
            colChange = 0;
        }

        colChange += 1;

    }

}
