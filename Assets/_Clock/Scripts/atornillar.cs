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
    bool rutinaEmpezada;
    public bool atornillado;
    int nivelAtornillado;
    GameObject caidaObjetos;
    CaidaObjetosScript caidaObjetosScript;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        nivelAtornillado = 0;
        caidaObjetos = GameObject.Find("CaidaObjetos");
        caidaObjetosScript = caidaObjetos.GetComponent<CaidaObjetosScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nivelAtornillado < 10)
        {
            if (!rutinaEmpezada)
            {
                StartCoroutine(noAtornillado());
                rutinaEmpezada = true;
            }

            //Detect when the up arrow key is pressed down
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //  transform.RotateAround(transform.position, Vector3.back, speed * Time.deltaTime);
                transform.Rotate(0.0f, 0.0f, -45f, Space.Self);
                nivelAtornillado++;
            }

            //Detect when the up arrow key is pressed down
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
                nivelAtornillado--;
            }
        }
        else
        {
            atornillado = true;
            rend.material.color = green;
            caidaObjetosScript.dejarCaerSiguiente();
            this.enabled = false;
        }
    }



    IEnumerator noAtornillado()
    {
        while (!atornillado)
        {
            rend.material.color = rojo;
            yield return new WaitForSeconds(.5f);
            rend.material.color = negro;
            yield return new WaitForSeconds(.5f);
        }
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
