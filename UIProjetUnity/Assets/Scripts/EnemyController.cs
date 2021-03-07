using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private Transform player;
    private Vector3 enemyOrigin;
    [SerializeField] private Animator anim;
    private float timeDelay = 3f;
    private float timer;
    [SerializeField] private Stats stats;
    private float stopAnim;
    [SerializeField] private StatManager healthbar;
    
    // Start is called before the first frame update
    void Awake()
    {
        enemyOrigin = enemy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, enemy.transform.position) < 10f)
        {
            setOrientation(player);
            chasePlayer();
            anim.SetBool("Walk Forward",true);
        }
        else if (Vector3.Distance(enemy.transform.position,enemyOrigin) > 1f)
        {
            //setOrientation(enemyOrigin);
            enemy.SetDestination(enemyOrigin);
            anim.SetBool("Walk Forward",true);
        }
        else
        {
            anim.SetBool("Walk Forward",false);
        }

        if (Vector3.Distance(player.position, enemy.transform.position) < 2f)
        {
            anim.SetBool("Walk Forward",false);
            attack();
        }
    }

    private void setOrientation(Transform player)
    {
        Vector3 direction = player.position - enemy.transform.position;
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(direction), 0.1f );
    }

    private void chasePlayer()
    {
        if (Vector3.Distance(player.position, enemy.transform.position) > 2f)
        {
            enemy.SetDestination(player.position);
        }
    }

    private void attack()
    {
        if (stats.Health <= 0)
        {
            SceneManager.LoadScene("DeathScene");
        }
        else
        {
            anim.SetBool("Attack",true);
            stats.Health -= Time.deltaTime * 5;
            healthbar.SetBar(stats.Health);
        }
        
    }
}
