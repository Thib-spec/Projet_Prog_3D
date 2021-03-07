using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class MoleController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private Transform player;
    [SerializeField] private Animator anim;

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(player.position, enemy.transform.position) < 3f)
        {
            setOrientation(player);
            fleePlayer();
            anim.SetBool("Walk Forward",true);
        }
    }

    private void setOrientation(Transform player)
    {
        Vector3 direction = player.position - enemy.transform.position;
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(direction), 0.1f );
    }

    private void fleePlayer()
    {
        if (Vector3.Distance(player.position, enemy.transform.position) > 2f)
        {
            enemy.SetDestination(new Vector3(Random.Range(-10,10),0f,Random.Range(-10,10)));
        }
    }

}


