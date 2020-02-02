using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonesMenu : MonoBehaviour
{
    public Animator controladorAnim;

    public Animator clara1;
    public Animator oscura1;
    public Animator clara2;
    public Animator oscura2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void botonDerecha()
    {
        cambioSentido();

        if (!controladorAnim.GetBool("primeraTransicion"))
        {
            controladorAnim.SetBool("primeraTransicion", true);
            controladorAnim.SetBool("muestraPlay", true);
        }
        else
        {
            controladorAnim.SetBool("muestraPlay", true);
        }
    }

    public void botonIzquierda()
    {
        cambioSentido();
        controladorAnim.SetBool("muestraPlay", false);
    }

    public void jugar()
    {

    }

    public void salir()
    {
        Application.Quit();
    }


    private void cambioSentido()
    {
        clara1.SetBool("girarIzquierda", !clara1.GetBool("girarIzquierda"));
        clara2.SetBool("girarIzquierda", !clara1.GetBool("girarIzquierda"));

        oscura1.SetBool("girarDerecha", !oscura1.GetBool("girarDerecha"));
        oscura2.SetBool("girarDerecha", !oscura2.GetBool("girarDerecha"));

    }
}
