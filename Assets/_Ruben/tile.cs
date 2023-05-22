using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Tile[] URDL = new Tile[4];
    public bool searched = false;
    public LayerMask tileLayer;
    public Tile searchedFrom;
    private Vector3[] dir = { Vector3.forward, Vector3.right, Vector3.back, Vector3.left };

    private void GetURDL()
    {
        for (int i = 0; i < URDL.Length; i++)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, dir[i]);

            if (Physics.Raycast(ray, out hit, 10.5f, tileLayer))
            {
                Tile tile = hit.collider.GetComponent<Tile>();
                URDL[i] = tile;
            }
        }
    }

    public void SearchTile()
    {
        for (int i = 0; i < 4; i++)
        {
            if (searchedFrom == URDL[i])
            {
                continue;
            }

            // Implement your code to search tiles and give back
        }
    }

    private void Start()
    {
        GetURDL();
        // Additional code if needed
    }

    // Additional methods or code if needed
}
