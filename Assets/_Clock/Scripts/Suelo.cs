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
        piezaActual = GameObject.FindWithTag("piece");
    }

    public void Update()
    {
        piezaActual = GameObject.FindWithTag("piece");
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(piezaActual);
        caidaObjetosScript.dejarCaerSiguiente();
    }
}
