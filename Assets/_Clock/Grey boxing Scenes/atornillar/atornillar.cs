using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atornillar : MonoBehaviour
{


    public int speed = 10;
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
        Debug.Log(transform.rotation.z);
        if(transform.rotation.z <= 1 && transform.rotation.z >= -1)
        {
            StartCoroutine(noAtornillado());

            //Detect when the up arrow key is pressed down
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

              //  transform.RotateAround(transform.position, Vector3.back, speed * Time.deltaTime);
                transform.Rotate(0.0f, 0.0f, -45f, Space.Self);

            }

            //Detect when the up arrow key is pressed down
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                transform.Rotate(0.0f, 0.0f, 45f, Space.Self);

            }
        }
        else
        {
            Debug.Log("else");
            StartCoroutine(Atornillado());
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
