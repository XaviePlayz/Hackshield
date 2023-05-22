using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    /*    public tile left, right, up, down;*/
    public tile[] URDL = new tile[4];
    public bool searched = false;
    public LayerMask tileLayer;
    public tile searchedFrom;
    private Vector3[] dir =
    {
        Vector3.forward, Vector3.right, Vector3.back, Vector3.left

    };

    private void getURDL()
    {
        for (int i = 0;  i< this.URDL.Length; i++)
        {
            RaycastHit hit;
            Ray ray = new Ray (transform.position, dir[i]);

            if (Physics.Raycast(ray, out hit, 10.5f, tileLayer))
            {
                tile tile = hit.collider.GetComponent<tile>();
                /*tile.searchedFrom = this;*/
                URDL[i]= tile;
                
            }

        } 
    }

    public void searchTile()
    {
        for (int i = 0; i < 4; i++) {
            if (searchedFrom == URDL[i]) { continue; }

            //search tiles and give back
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        getURDL();
        

        
    }

}
