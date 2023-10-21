using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform player;

    public Transform button1;
    public Transform button2;

    public Transform lowerHalf;
    public Transform upperHalf;

    public Vector3 openPos1;
    public Vector3 openPos2;
    public Vector3 closedPos1;
    public Vector3 closedPos2;

    public float doorSpeed = 3f;
    public bool moving = false;
    public bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        closedPos1 = lowerHalf.position;
        closedPos2 = upperHalf.position;

        openPos1 = closedPos1 - new Vector3(0, 3, 0);
        openPos2 = closedPos2 + new Vector3(0, 3, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, button1.position) < 2f || Vector3.Distance(player.position, button2.position) < 2f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("open sesame");
                toggleDoor();
            }
        }

        if (isOpen)
        {
            if (moving == true)
            {
                lowerHalf.position = Vector3.MoveTowards(lowerHalf.position, openPos1, doorSpeed * Time.deltaTime);
                if (Vector3.Distance(lowerHalf.position, openPos1) < .001f)
                {
                    moving = false;
                }
                }
            if (moving == true)
            {
                upperHalf.position = Vector3.MoveTowards(upperHalf.position, openPos2, doorSpeed * Time.deltaTime);
                if (Vector3.Distance(upperHalf.position, openPos2) < .001f)
                {
                    moving = false;
                }
            }
        }
        else
        {
            if (moving == true)
            {
                lowerHalf.position = Vector3.MoveTowards(lowerHalf.position, closedPos1, doorSpeed * Time.deltaTime);
                if (Vector3.Distance(lowerHalf.position, closedPos1) < .001f)
                {
                    moving = false;
                }
            }
            if (moving == true)
            {
                upperHalf.position = Vector3.MoveTowards(upperHalf.position, closedPos2, doorSpeed * Time.deltaTime);
                if (Vector3.Distance(lowerHalf.position, closedPos1) < .001f)
                {
                    moving = false;
                }
            }
        }
    }

    public void toggleDoor()
    {
        moving = true;
        isOpen = !isOpen;
    }
}
