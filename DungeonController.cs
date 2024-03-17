using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject northDoor, southDoor, eastDoor, westDoor;
    public GameObject northPickup, southPickup, westPickup, eastPickup;

    void Start()
    {
        Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();

        turnOffPickup();
        if(theCurrentRoom.hasExit("north"))
        {
            this.northDoor.SetActive(false);
            this.northPickup.gameObject.SetActive(true);
        }
        else
        {
            this.northDoor.SetActive(true);
        }

        if (theCurrentRoom.hasExit("south"))
        {
            this.southDoor.SetActive(false);
            this.southPickup.gameObject.SetActive(true);
        }
        else
        {
            this.southDoor.SetActive(true);
        }

        if (theCurrentRoom.hasExit("east"))
        {
            this.eastDoor.SetActive(false);
            this.eastPickup.gameObject.SetActive(true);
        }
        else
        {
            this.eastDoor.SetActive(true);
        }

        if (theCurrentRoom.hasExit("west"))
        {
            this.westDoor.SetActive(false);
            this.westPickup.gameObject.SetActive(true);
        }
        else
        {
            this.westDoor.SetActive(true);
        }
        
    }

    public void turnOffPickup()
    {
    this.northPickup.gameObject.SetActive(false);
    this.southPickup.gameObject.SetActive(false);
    this.westPickup.gameObject.SetActive(false);
    this.eastPickup.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
