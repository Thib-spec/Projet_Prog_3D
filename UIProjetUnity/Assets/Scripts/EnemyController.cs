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
    private float timeDelay = 5f;
    private float timer;
    [SerializeField] private Stats stats;
    private float stopAnim;
    [SerializeField] private StatManager healthbar;
    [SerializeField] private AudioClip monsterClip;
    [SerializeField] private AudioSource source;
    
    // Start is called before the first frame update
    void Awake()
    {
        enemyOrigin = enemy.transform.position;  // Initialisation origine de l'ennemie
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Vector3.Distance(player.position, enemy.transform.position) < 10f) // Si le joueur s'approche
        {
            setOrientation(player); // L'ennemie s'oriente vers lui
            chasePlayer(); // Puis avance vers lui
            anim.SetBool("Walk Forward",true); // On lance l'animation de marche
        }
        else if (Vector3.Distance(enemy.transform.position,enemyOrigin) > 1f) // Si le joueur est loin et que l'ennemie s'est déplacé
        {
            //setOrientation(enemyOrigin);
            enemy.SetDestination(enemyOrigin); // L'ennemie retourne à son point d'origine
            anim.SetBool("Walk Forward",true);
        }
        else 
        {
            anim.SetBool("Walk Forward",false); // On arrete la marche sinon
        }

        if (Vector3.Distance(player.position, enemy.transform.position) < 2f) // Si l'ennemie est assez proche du joueur
        {
            anim.SetBool("Walk Forward",false);
            attack(); // Il attaque
        }
    }

    private void setOrientation(Transform player) // Fonction d'orientation
    {
        Vector3 direction = player.position - enemy.transform.position; // Nouveau vecteur d'orientation
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(direction), 0.1f ); // On applique l'orientation
    }

    private void chasePlayer() // Fonction de suivi du joueur
    {
        if (Vector3.Distance(player.position, enemy.transform.position) > 2f) // Définition d'une distance d'arrêt
        {
            enemy.SetDestination(player.position); // Destination de l'ennemie sur la position du joueur
            if (timer >= timeDelay && !source.isPlaying) //On joue le son du monstre après un délai et
            //si celui-ci n'est pas déjà en train d'être joué
            {
                source.PlayOneShot(monsterClip);
                timer = 0;
            }
            
        }
    }

    private void attack() // Fonction d'attaque
    {
        anim.SetBool("Attack",true); // Animation d'attaque
        stats.Health -= Time.deltaTime * 5; // Diminution de la vie du joueur
        healthbar.SetBar(stats.Health); // Actualisation de la barre de vie du joueur
    }
}
