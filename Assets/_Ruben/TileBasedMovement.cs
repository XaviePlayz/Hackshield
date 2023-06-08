using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBasedMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform characterTransform;
    public LayerMask tileLayer;

    private List<Vector3> path;
    private int currentPathIndex;
    private bool isMoving = false;
    public tile[] allTiles;
    public tile currentTile;

    private void Start()
    {
        allTiles = GameObject.FindObjectsOfType<tile>();
    }
    private void Update()
    {
         if (Input.GetMouseButtonDown(0))
         {
             RaycastHit hit;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

             if (Physics.Raycast(ray, out hit, Mathf.Infinity, tileLayer))
             {
                 // Calculate the target position based on the clicked tile
                 Vector3 targetPosition = hit.collider.transform.position;

                 // Ensure the target position is aligned to the grid (optional)
                 targetPosition.x = Mathf.Round(targetPosition.x);
                 targetPosition.z = Mathf.Round(targetPosition.z);

                 if (!isMoving)
                 {
                   
                     // Find a path to the target position using A* algorithm
                     path = FindPath(characterTransform.position, targetPosition);

                     if (path != null && path.Count > 0)
                     {
                         Debug.Log("gevonden");
                         currentPathIndex = 0;
                         isMoving = true;
                         StartCoroutine(MoveAlongPath());
                     }
                 }
             }
         }
    }

    private System.Collections.IEnumerator MoveAlongPath()
    {
        while (currentPathIndex < path.Count)
        {
            Vector3 targetPosition = path[currentPathIndex];

            while (Vector3.Distance(characterTransform.position, targetPosition) > 0.1f)
            {
                characterTransform.position = Vector3.MoveTowards(characterTransform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            // Update the character position to the target position precisely
            characterTransform.position = targetPosition;

            currentPathIndex++;
        }

        // Movement complete
        isMoving = false;
    }


    private List<Vector3> FindPath(Vector3 startPosition, Vector3 targetPosition)
    {
        // stores all the paths that are possible 
        List<List<tile>> paths = new List<List<tile>>();
        /*tile currT = currenttile;*/
        bool pathComplete = false;
        int index = 0;

        /*while (!pathComplete)*/

        for (int x = 0; x < 10000; x++)
        {
            //check all paths
            for (int i = 0; i < paths.ToArray().Length; i++)
            {
                //get active path
                List<tile> path = paths[i];
                tile lastSearchedTileInActivePath = path[path.Count];
                //increment active path 1
                for (int j = 0; j < lastSearchedTileInActivePath.URDL.Length; j++)
                {
                    if (lastSearchedTileInActivePath.URDL[j] == null) { continue; }
                    // If not null the execute code

                    StartCoroutine(walkPath(path));

                }
            }

            //increment when path is not complete but needs another round
            index++;
        }


        return path;
    }

    private IEnumerator walkPath(List<tile> endPath)
    {
        int currentWaypoint = 0;
        while (currentWaypoint != endPath.Count)
        {
            characterTransform.position = Vector3.MoveTowards(characterTransform.position, endPath[currentWaypoint + 1].transform.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(characterTransform.position, endPath[currentWaypoint + 1].transform.position) < 0.2f)
            {
                currentWaypoint++;
            }
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Gehaald");
        yield return null;
    }
}