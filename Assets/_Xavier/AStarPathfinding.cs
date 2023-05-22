using UnityEngine;
using UnityEngine.AI;

public class AStarPathfinding : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    private NavMeshPath path;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
    }

    private void CalculatePath()
    {
        agent.CalculatePath(target.position, path);
    }

}