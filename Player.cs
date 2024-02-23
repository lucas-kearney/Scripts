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
    private GameObject[] triggers;
    private int randomExits;

    

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

        triggers = new GameObject[] { northExit, southExit, eastExit, westExit };
        //disable all exits when the scene first loads
        triggers = GameObject.FindGameObjectsWithTag("exit");

        Debug.Log("Number of exit triggers found: " + triggers.Length);
        
        this.turnOffExits();

        //not our first scene
        if (!MySingleton.currentDirection.Equals("?"))
        {
            if(MySingleton.currentDirection.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
            }
            else if (MySingleton.currentDirection.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
            }
            else if (MySingleton.currentDirection.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
            }
            else if (MySingleton.currentDirection.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
            }

            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered: " + other.gameObject.name);
        
        if(other.CompareTag("exit"))
        {
            EditorSceneManager.LoadScene("Scene1");
            DeactivateRandomTriggers();
        }
        else if(other.CompareTag("middleOfTheRoom") && !MySingleton.currentDirection.Equals("?"))
        {
            print("at middle of Room");
            this.amAtMiddleOfRoom = true;
        }

        
    }


    public void DeactivateRandomTriggers()
{
    ShuffleArray(triggers);
    randomExits = UnityEngine.Random.Range(0, triggers.Length);
    Debug.Log("Random exits: " + randomExits);
    for (int i = 0; i < randomExits; i++)
    {
        if (i < triggers.Length && triggers[i] != null)
        {
            triggers[i].SetActive(false);
        }
        else
        {
            Debug.LogWarning("Skipping null or out-of-bounds trigger at index " + i);
            Debug.Log("Triggers length: " + triggers.Length);
            Debug.Log("Trigger at index " + i + ": " + (triggers[i] == null ? "null" : triggers[i].name));
        }
    }
}
    

    // Method to shuffle the elements of an array
    private void ShuffleArray<T>(T[] array)
{
    for (int i = array.Length - 1; i >= 0; i--)
    {
        int randomIndex = UnityEngine.Random.Range(0, i + 1);
        T temp = array[i];
        array[i] = array[randomIndex];
        array[randomIndex] = temp;
        Debug.Log("The Deactivated exits are: " + array);
    }
}

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
        
        
        if (Input.GetKeyUp(KeyCode.UpArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "north";
            this.gameObject.transform.LookAt(this.northExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "south";
            this.gameObject.transform.LookAt(this.southExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "west";
            this.gameObject.transform.LookAt(this.westExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving)
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
