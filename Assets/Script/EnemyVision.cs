using UnityEngine;
using UnityEngine.AI;

public class EnemyVision : MonoBehaviour
{
    public Transform player;
    public Vector3 startPosition;

    private NavMeshAgent agent;
    private bool playerDetected = false;

    void Start()
    {
        // Get the NavMeshAgent from the parent Enemy object
        agent = GetComponentInParent<NavMeshAgent>();

        startPosition = agent.transform.position;
    }

    void Update()
    {
        if (playerDetected)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.SetDestination(startPosition);
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