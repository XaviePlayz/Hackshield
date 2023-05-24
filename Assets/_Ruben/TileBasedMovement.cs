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
    public Tile[] allTiles;
    public Tile currentTile;

    private void Start()
    {
        allTiles = GameObject.FindObjectsOfType<Tile>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, tileLayer))
            {
                Vector3 targetPosition = hit.collider.transform.position;
                targetPosition.x = Mathf.Round(targetPosition.x);
                targetPosition.z = Mathf.Round(targetPosition.z);

                if (!isMoving)
                {
                    path = FindPath(characterTransform.position, targetPosition);

                    if (path != null && path.Count > 0)
                    {
                        currentPathIndex = 0;
                        isMoving = true;
                        StartCoroutine(MoveAlongPath());
                    }
                }
            }
        }
    }

    private IEnumerator MoveAlongPath()
    {
        while (currentPathIndex < path.Count)
        {
            Vector3 targetPosition = path[currentPathIndex];

            while (Vector3.Distance(characterTransform.position, targetPosition) > 0.1f)
            {
                characterTransform.position = Vector3.MoveTowards(characterTransform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            characterTransform.position = targetPosition;
            currentPathIndex++;
        }

        isMoving = false;
    }

    private List<Vector3> FindPath(Vector3 startPosition, Vector3 targetPosition)
    {
        List<List<Tile>> paths = new List<List<Tile>>();
        List<Tile> initialPath = new List<Tile>();
        initialPath.Add(currentTile);
        paths.Add(initialPath);
        bool pathComplete = false;

        for (int x = 0; x < 1000; x++)
        {
            if (!pathComplete)
            {
                for (int i = 0; i < paths.Count; i++)
                {
                    List<Tile> path = paths[i];
                    Tile lastSearchedTileInActivePath = path[path.Count - 1];

                    for (int j = 0; j < lastSearchedTileInActivePath.URDL.Length; j++)
                    {
                        if (lastSearchedTileInActivePath.URDL[j] == null)
                        {
                            continue;
                        }

                        List<Tile> newPath = new List<Tile>(path);
                        newPath.Add(lastSearchedTileInActivePath.URDL[j]);

                        if (lastSearchedTileInActivePath.URDL[j].transform.position == targetPosition)
                        {
                            pathComplete = true;
                            return ConvertTilesToPositions(newPath);
                        }
                        else
                        {
                            paths.Add(newPath);
                        }
                    }
                }
            }
            else
            {
                Debug.Log("Done");
            }
        }
        /*while (!pathComplete)
        {
            for (int i = 0; i < paths.Count; i++)
            {
                List<Tile> path = paths[i];
                Tile lastSearchedTileInActivePath = path[path.Count - 1];

                for (int j = 0; j < lastSearchedTileInActivePath.URDL.Length; j++)
                {
                    if (lastSearchedTileInActivePath.URDL[j] == null)
                    {
                        continue;
                    }

                    List<Tile> newPath = new List<Tile>(path);
                    newPath.Add(lastSearchedTileInActivePath.URDL[j]);

                    if (lastSearchedTileInActivePath.URDL[j].transform.position == targetPosition)
                    {
                        pathComplete = true;
                        return ConvertTilesToPositions(newPath);
                    }
                    else
                    {
                        paths.Add(newPath);
                    }
                }
            }
        }*/

        return null;
    }

    private List<Vector3> ConvertTilesToPositions(List<Tile> tiles)
    {
        List<Vector3> positions = new List<Vector3>();

        foreach (Tile tile in tiles)
        {
            positions.Add(tile.transform.position);
        }

        return positions;
    }
}
