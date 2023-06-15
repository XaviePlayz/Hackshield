using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class CharacterControlScript : MonoBehaviour
{
    public Camera cam;
    [SerializeField] private NavMeshAgent player;
    public GameObject targetDestination;
    public SceneManagerScript sceneManager;
    [SerializeField] private Animator anim;

    public bool inComputer;

    private void Start()
    {
        player = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

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

                if (Physics.Raycast(ray, out hitPoint, 100, layerMask) && !inComputer)
                {
                    targetDestination.transform.position = hitPoint.point;
                    player.SetDestination(hitPoint.point);
                }
            }
        }

        if (player.velocity != Vector3.zero)
        {
            //Player Moves Animation
            anim.SetTrigger("Walk");
        }
        if (player.velocity == Vector3.zero)
        {
            //Player Idle Animation
            anim.SetTrigger("Idle");

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable_Computer")
        {
            sceneManager.ToggleAdditiveScene();
        }

        if (other.gameObject.tag == "Portal")
        {
            SceneManager.LoadScene(1);
        }
    }


}