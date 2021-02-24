using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, enemy.transform.position) < 10f)
        {
            setOrientation();
            chasePlayer();
        }
    }

    private void setOrientation()
    {
        Vector3 direction = player.position - enemy.transform.position;
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(direction), 0.1f );
    }

    private void chasePlayer()
    {
        if (Vector3.Distance(player.position, enemy.transform.position) > 1f)
        {
            enemy.SetDestination(player.position);
        }
    }
}
