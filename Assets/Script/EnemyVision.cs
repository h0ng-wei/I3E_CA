using UnityEngine;
using UnityEngine.AI;

public class EnemyVision : MonoBehaviour
{
    public Transform player;

    private NavMeshAgent agent;
    private bool playerDetected = false;

    void Start()
    {
        // Get the NavMeshAgent from the parent Enemy object
        agent = GetComponentInParent<NavMeshAgent>();
    }

    void Update()
    {
        if (playerDetected)
        {
            agent.SetDestination(player.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = true;
            Debug.Log("Player Detected!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = false;
            Debug.Log("Player Left Vision!");
        }
    }
}