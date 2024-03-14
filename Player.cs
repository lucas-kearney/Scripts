using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    private string name;
    private Room currentRoom;

    public Player(string name)
    {
        this.name = name;
        this.currentRoom = null;
    }
    public void setCurrentRoom(Room r)
    {
        this.currentRoom = r;
    }

    public Room getCurrentRoom()
    {
        return this.currentRoom;
    }

   
}