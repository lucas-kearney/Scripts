using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject[] closedDoors;
    public GameObject[] exitObjects;
    
    private string mapIndexToStringForExit(int index)
    {
        if(index == 0)
        {
            return "north";
        }
        else if(index == 1)
        {
            return "south";
        }
        else if(index == 2)
        {
            return "east";
        }
        else if(index == 3)
        {
            return "west";
        }
        else
        {
            return "?";       
        }
    }
   
   
    void Start()
    {
        closedDoors = GameObject.FindGameObjectsWithTag("closedDoor");
       
       MySingleton.theCurrentRoom = new Room("a room");
       MySingleton.addRoom(MySingleton.theCurrentRoom);

       int openDoorIndex = Random.Range(0, 4);
       closedDoors[openDoorIndex].SetActive(false);
       this.exitObjects[openDoorIndex].SetActive(false);
       MySingleton.theCurrentRoom.setDoorOpen(this.mapIndexToStringForExit(openDoorIndex));

       for(int i = 0; i < 4; i++)
       {
        if(openDoorIndex != i)
        {
            int coinFlip = Random.Range(0, 2);
            if(coinFlip == 1)
            {
                closedDoors[i].SetActive(false);
                this.exitObjects[i].SetActive(false);
                MySingleton.theCurrentRoom.setDoorOpen(this.mapIndexToStringForExit(i));
            }
        }
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
