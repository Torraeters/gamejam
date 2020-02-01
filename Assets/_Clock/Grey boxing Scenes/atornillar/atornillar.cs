using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atornillar : MonoBehaviour
{


    public int speed = 10;
    public bool isAtornillado = false;
    public SpriteRenderer rend;
    public Color negro = Color.black;
    public Color rojo = Color.red;
    public Color green = Color.green;



    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(noAtornillado());


        //Detect when the up arrow key is pressed down
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            transform.RotateAround(transform.position, Vector3.back, speed * Time.deltaTime);
            if (transform.rotation.z >= .5)
            {

                StartCoroutine(Atornillado());
                isAtornillado = true;

            }

        }




        //Detect when the up arrow key is pressed down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            transform.RotateAround(transform.position, Vector3.forward, speed * Time.deltaTime);
            if (transform.rotation.z >= -.5)
            {

                StartCoroutine(Atornillado());
                isAtornillado = true;

            }

        }
    }



    IEnumerator noAtornillado()
    {
        rend.material.color = rojo;
        yield return new WaitForSeconds(0.6f);
        rend.material.color = negro;
        yield return new WaitForSeconds(0.3f);
        rend.material.color = rojo;
        yield return new WaitForSeconds(0.3f);
        rend.material.color = negro;
        yield return new WaitForSeconds(0.1f);
        rend.material.color = rojo;
        yield return new WaitForSeconds(0.1f);
        rend.material.color = negro;
    }

    IEnumerator Atornillado()
    {
        rend.material.color = green;
        yield return new WaitForSeconds(0.6f);
        rend.material.color = negro;
        yield return new WaitForSeconds(0.3f);
        rend.material.color = green;
        yield return new WaitForSeconds(0.3f);
        rend.material.color = negro;
        yield return new WaitForSeconds(0.1f);
        rend.material.color = green;
        yield return new WaitForSeconds(0.1f);
        rend.material.color = negro;
    }
}
