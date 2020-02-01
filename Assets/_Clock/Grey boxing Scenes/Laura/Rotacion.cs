using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    private int velocity = 10;
    public float velocityDown = -0.2f;
    private int grads = 45;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, velocityDown * Time.deltaTime, 0, Space.World);
        if (Input.GetButton("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.Translate(velocity * Time.deltaTime, 0, 0, Space.World);
            }
            else
            {
                transform.Translate(-velocity * Time.deltaTime, 0, 0, Space.World);
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            transform.Rotate(0, 0, grads);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            transform.Rotate(0, 0, -grads);
        }
    }
}
