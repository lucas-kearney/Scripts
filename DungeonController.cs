using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject northDoor, southDoor, eastDoor, westDoor;


    void Start()
    {
        Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();

        
        if(theCurrentRoom.hasExit("north"))
        {
            this.northDoor.SetActive(false);
        }
        else
        {
            this.northDoor.SetActive(true);
        }

        if (theCurrentRoom.hasExit("south"))
        {
            this.southDoor.SetActive(false);
        }
        else
        {
            this.southDoor.SetActive(true);
        }

        if (theCurrentRoom.hasExit("east"))
        {
            this.eastDoor.SetActive(false);
        }
        else
        {
            this.eastDoor.SetActive(true);
        }

        if (theCurrentRoom.hasExit("west"))
        {
            this.westDoor.SetActive(false);
        }
        else
        {
            this.westDoor.SetActive(true);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}