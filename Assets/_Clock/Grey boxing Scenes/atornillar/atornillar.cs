using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atornillar : MonoBehaviour
{

    GameObject hole;
    public int speed;
    Encajar encajar;
    GameObject tornillo;
    Objeto obj;


    // Start is called before the first frame update
    void Start()
    {
        hole = GameObject.FindWithTag("hole");
        encajar = hole.GetComponent<Encajar>();
        tornillo = GameObject.FindWithTag("tornillo");
        obj = tornillo.GetComponent<Objeto>();

    }

    // Update is called once per frame
    void Update()
    {
        if(encajar.targetPiece != null)
        {
            if (encajar.isFitIn == true)
            {


                //Detect when the up arrow key is pressed down
                if (Input.GetKeyDown(KeyCode.UpArrow))
                    obj.transform.RotateAround(transform.position, Vector3.back, speed * Time.deltaTime);

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
    }
}
