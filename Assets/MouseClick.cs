using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    public GameObject profiles;
    public GameObject player;
    public bool startMovingForward;
    public bool startMovingLeft;
    public bool startMovingRight;

    public float degreesPerSecond = 90;
    public bool startTurningLeft;
    public bool startTurningRight;

    public bool computerActivated;
    void Start()
    {
        profiles.SetActive(false);
        
    }

    void Update()
    {
        if (startMovingForward)
        {
            player.transform.position += new Vector3(0, 0, 0.0128f);
        }
        if (startMovingLeft)
        {
            player.transform.position += new Vector3(-0.0128f, 0, 0);
        }
        if (startMovingRight)
        {
            player.transform.position += new Vector3(0.0128f, 0, 0);
        }
        if (startTurningLeft)
        {
            player.GetComponent<Transform>().transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);
        }
        if (startTurningRight)
        {
            player.GetComponent<Transform>().transform.Rotate(new Vector3(0, 0, -degreesPerSecond) * Time.deltaTime);
        }

        if (!computerActivated)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(StartDemo());
            }
            
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(TurnLeft());
            }
            if (Input.GetMouseButtonDown(1))
            {
                StartCoroutine(TurnRight());
            }
        }
    }
    public IEnumerator StartDemo()
    {
        startMovingForward = true;
        yield return new WaitForSeconds(2.4f);
        startMovingForward = false;
        profiles.SetActive(true);
        computerActivated = true;
    }

    public IEnumerator TurnLeft()
    {
        startTurningLeft = true;
        yield return new WaitForSeconds(1f);
        startTurningLeft = false;
        startMovingLeft = true;
        yield return new WaitForSeconds(3.8f);
        startMovingLeft = false;
        profiles.SetActive(true);
    }
    public IEnumerator TurnRight()
    {
        startTurningRight = true;
        yield return new WaitForSeconds(1f);
        startTurningRight = false;
        startMovingRight = true;
        yield return new WaitForSeconds(5.1f);
        startMovingRight = false;
        profiles.SetActive(true);
    }
}
