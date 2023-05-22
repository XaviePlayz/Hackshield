using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileProgressionSystem : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public LayerMask clickableLayer;

    private Tile currentTile;
    private Tile targetTile;
    private bool isMoving;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer))
            {
                Tile clickedTile = hit.collider.GetComponent<Tile>();
                if (clickedTile != null)
                {
                    targetTile = clickedTile;
                    StartCoroutine(MoveToTile());
                }
            }
        }
    }

    private IEnumerator MoveToTile()
    {
        isMoving = true;

        while (Vector3.Distance(player.position, targetTile.transform.position) > 0.01f)
        {
            Vector3 direction = (targetTile.transform.position - player.position).normalized;
            player.position += direction * moveSpeed * Time.deltaTime;
            yield return null;
        }

        player.position = targetTile.transform.position;
        currentTile = targetTile;
        isMoving = false;
    }
}