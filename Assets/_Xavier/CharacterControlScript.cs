using UnityEngine;
using UnityEngine.AI;

public class CharacterControlScript : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent player;
    public GameObject targetDestination;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            if (Physics.Raycast(ray, out hitPoint))
            {
                targetDestination.transform.position = hitPoint.point;
                player.SetDestination(hitPoint.point);
            }
        }

        if (player.velocity != Vector3.zero)
        {
            //Player Moves Animation
        }
        if (player.velocity == Vector3.zero)
        {
            //Player Idle Animation
        }
    }
}
