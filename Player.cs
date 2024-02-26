using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;



public class Player : MonoBehaviour
{
    
    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;
    private float speed = 5.0f;
    private bool amMoving = false;
    private bool amAtMiddleOfRoom = false;
    

    

    private void turnOffExits()
    {
        this.northExit.gameObject.SetActive(false);
        this.southExit.gameObject.SetActive(false);
        this.eastExit.gameObject.SetActive(false);
        this.westExit.gameObject.SetActive(false);

    }

    private void turnOnExits()
    {
        this.northExit.gameObject.SetActive(true);
        this.southExit.gameObject.SetActive(true);
        this.eastExit.gameObject.SetActive(true);
        this.westExit.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
    
        
        this.turnOffExits();
        DungeonController dungeonController = FindObjectOfType<DungeonController>();

        if(dungeonController != null)
        {

        
        //not our first scene
        if (!MySingleton.currentDirection.Equals("?"))
        {
            if(MySingleton.currentDirection.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
                dungeonController.closedDoors[3].SetActive(true);
            }
            else if (MySingleton.currentDirection.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
                dungeonController.closedDoors[2].SetActive(true);
            }
            else if (MySingleton.currentDirection.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
                dungeonController.closedDoors[1].SetActive(true);
            }
            else if (MySingleton.currentDirection.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
                dungeonController.closedDoors[0].SetActive(true);
            }

            
        }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered: " + other.gameObject.name);
        
        if(other.CompareTag("exit"))
        {
            EditorSceneManager.LoadScene("Scene1");
            
        }
        else if(other.CompareTag("middleOfTheRoom") && !MySingleton.currentDirection.Equals("?"))
        {
            print("at middle of Room");
            this.amAtMiddleOfRoom = true;
        }
    }
        
    


    // Method to shuffle the elements of an array
   

    // Update is called once per frame
    void Update()
    {
        if(amAtMiddleOfRoom)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            //return;
            if (Input.anyKey)
        {
            amAtMiddleOfRoom = false; // Reset the flag when any key is pressed
        }
        return;
        }
    
        
        
        
        if (Input.GetKeyUp(KeyCode.UpArrow) && !this.amMoving && MySingleton.theCurrentRoom.isOpenDoor("north"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "north";
            this.gameObject.transform.LookAt(this.northExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving && MySingleton.theCurrentRoom.isOpenDoor("south"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "south";
            this.gameObject.transform.LookAt(this.southExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving && MySingleton.theCurrentRoom.isOpenDoor("west"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "west";
            this.gameObject.transform.LookAt(this.westExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving && MySingleton.theCurrentRoom.isOpenDoor("east"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "east";
            this.gameObject.transform.LookAt(this.eastExit.transform.position);

        }

        //make the player move in the current direction
        if (MySingleton.currentDirection.Equals("north"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.northExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("south"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.southExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("west"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.westExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("east"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.eastExit.transform.position, this.speed * Time.deltaTime);
        }
    }
}
