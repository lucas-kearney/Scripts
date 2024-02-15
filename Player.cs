using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
   private Rigidbody rb;
   private float movementX;
    private float movementY;
    public float speed = 0;
    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        print("You are now in room one");
        if(!MySingleton.currentDirection.Equals("?"))
        {
            if(MySingleton.currentDirection.Equals("North Exit"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
            }
        }
    }


    

    public void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("exit"))
       {
         MySingleton.currentDirection = "North Exit";
         EditorSceneManager.LoadScene("Scene2");
       }
        
    }

    void OnMove (InputValue movementValue)
   {
    Vector2 movementVector = movementValue.Get<Vector2>(); 
    this.movementX = movementVector.x; 
    this.movementY = movementVector.y;
   }

    private void FixedUpdate() 
   {
    Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
    rb.AddForce(movement * speed);
   }
    
   
}
