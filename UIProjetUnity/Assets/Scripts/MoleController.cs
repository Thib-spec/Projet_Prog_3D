using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class MoleController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private Transform player;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioClip moleClip;
    [SerializeField] private AudioSource source;
    private float timeDelay = 5f;
    private float timer;
    

    private void Update()
    {
        timer += Time.deltaTime;
        if (Vector3.Distance(player.position, enemy.transform.position) < 3f) // Si le joueur s'approche de la taupe
        {
            setOrientation(player); // La taupe s'oriente vers lui
            fleePlayer(); // Et s'enfuit
            if (!source.isPlaying && timer>=timeDelay) //On joue le son de la taupe après un délai
            //et si celui-ci n'est pas déjà en train d'être joué
            {
                source.PlayOneShot(moleClip);
                timer = 0;
            }
            anim.SetBool("Walk Forward",true); // On active l'animation de marche
        }
    }
    
    private void setOrientation(Transform player) // Fonction d'orientation
    {
        Vector3 direction = player.position - enemy.transform.position; // Nouveau vecteur d'orientation
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(direction), 0.1f ); // On applique l'orientation
    }
    
    private void fleePlayer() // Fonction de fuite de la taupe
    {
        if (Vector3.Distance(player.position, enemy.transform.position) > 2f)
        {
            Vector3 point; // Vecteur de destination de la taupe
            if (RandomPoint(transform.position, range, out point)) // Definition de la destination
            {
                enemy.SetDestination(point);
            }
        }
    }
    
    public float range = 10.0f;
    bool RandomPoint(Vector3 center, float range, out Vector3 result) { // Fonction qui définit la nouvelle destination sur une partie du NavMesh
        for (int i = 0; i < 30; i++) {                                  // Pour que la taupe ne sorte pas de la dernière zone
            Vector3 randomPoint = center + Random.insideUnitSphere * range; // Calcul d'un point aléatoire
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.GetAreaFromName("floor1"))) { // Si le point appartient au bon Navmesh
                result = hit.position; // On renvoit le point
                return true;
            }
        }
        result = Vector3.zero; // Si aucun point n'est trouvé on renvoit le vecteur nul
        return false;
    }
}


