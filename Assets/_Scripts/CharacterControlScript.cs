using UnityEngine;
using UnityEngine.AI;

public class CharacterControlScript : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent player;
    public GameObject targetDestination;
    public SceneManagerScript sceneManager;

 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            //Convert Layer Name to Layer Number
            int tileLayerIndex = LayerMask.NameToLayer("Tiles");

            //Check if layer is valid
            if (tileLayerIndex == -1)
            {
                Debug.LogError("Layer Does not exist");
            }
            else
            {
                //Calculate layermask to Raycast to. (Raycast to "Tiles" layer only)
                int layerMask = (1 << tileLayerIndex);

                Vector3 fwd = transform.TransformDirection(Vector3.forward);

                if (Physics.Raycast(ray, out hitPoint, 100, layerMask))
                {
                    targetDestination.transform.position = hitPoint.point;
                    player.SetDestination(hitPoint.point);
                }
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable_Computer")
        {
            sceneManager.ToggleAdditiveScene();
        }
    }
}