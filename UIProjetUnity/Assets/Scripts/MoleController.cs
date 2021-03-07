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
        if (Vector3.Distance(player.position, enemy.transform.position) < 3f)
        {
            setOrientation(player);
            fleePlayer();
            if (!source.isPlaying && timer>=timeDelay) //On joue le son de la taupe après un délai
            //et si celui-ci n'est pas déjà en train d'être joué
            {
                source.PlayOneShot(moleClip);
                timer = 0;
            }
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
            Vector3 point;
            if (RandomPoint(transform.position, range, out point))
            {
                enemy.SetDestination(point);
            }
        }
    }
    
    public float range = 10.0f;
    bool RandomPoint(Vector3 center, float range, out Vector3 result) {
        for (int i = 0; i < 30; i++) {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.GetAreaFromName("floor1"))) {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}


