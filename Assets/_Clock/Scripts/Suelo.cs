using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suelo : MonoBehaviour
{
    GameObject caidaObjetos;

    CaidaObjetosScript caidaObjetosScript;

    GameObject piezaActual;

    public void Start()
    {
        caidaObjetos = GameObject.Find("CaidaObjetos");
        caidaObjetosScript = caidaObjetos.GetComponent<CaidaObjetosScript>();
        if (GameObject.FindWithTag("piece") != null)
        {
            piezaActual = GameObject.FindWithTag("piece");
        }
        else if (GameObject.FindWithTag("tornillo") != null)
        {
            piezaActual = GameObject.FindWithTag("tornillo");
        }
    }

    public void Update()
    {
        if (GameObject.FindWithTag("piece") != null)
        {
            piezaActual = GameObject.FindWithTag("piece");
        }
        else if (GameObject.FindWithTag("tornillo") != null)
        {
            piezaActual = GameObject.FindWithTag("tornillo");
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(piezaActual);
        caidaObjetosScript.dejarCaerSiguiente();
    }
}
