using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class MonsterController : MonoBehaviour
{
    public GameObject Scene2Monster;
    public float speed = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }



    void onTriggerEnter(Collider other)
    {
        if(other.CompareTag("monster"))
        {
            EditorSceneManager.LoadScene("Scene2");
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.Scene2Monster.transform.position, this.speed * Time.deltaTime);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
