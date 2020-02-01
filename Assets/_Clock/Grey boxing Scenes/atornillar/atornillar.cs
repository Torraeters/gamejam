using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atornillar : MonoBehaviour
{


    public int speed;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


                //Detect when the up arrow key is pressed down
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Debug.Log("hola");
                    transform.RotateAround(transform.position, Vector3.back, speed * Time.deltaTime);
                    Debug.Log("adios");
                }



                //Detect when the up arrow key has been released
                if (Input.GetKeyUp(KeyCode.UpArrow))
                    Debug.Log("Up Arrow key was released.");

                //Detect when the up arrow key is pressed down
                if (Input.GetKeyDown(KeyCode.DownArrow))
                    Debug.Log("Up Arrow key was pressed.");

                //Detect when the up arrow key has been released
                if (Input.GetKeyUp(KeyCode.DownArrow))
                    Debug.Log("Up Arrow key was released.");
            }
        

}
