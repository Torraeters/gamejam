using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class botonesMenu : MonoBehaviour
{
    public Animator controladorAnim;

    public Animator clara1;
    public Animator oscura1;
    public Animator clara2;
    public Animator oscura2;

    private bool playEnPantalla;
    


    // Start is called before the first frame update
    void Start()
    {
        playEnPantalla = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Pulsado enter");
            Debug.Log("valore del booleano" + playEnPantalla);
            if (playEnPantalla)
            {
                Debug.Log("dentro if, true");
                jugar();
            }
            else
            {
                Debug.Log("Dentro del else");
                salir();
            }
        }

        if (Input.GetKeyDown("left"))
        {
            botonIzquierda();
        }

        if (Input.GetKeyDown("right"))
        {
            botonDerecha();
        }

    }

    public void botonDerecha()
    {

        playEnPantalla = false;

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
        playEnPantalla = true;

        cambioSentido();
        controladorAnim.SetBool("muestraPlay", false);

    }

    public void jugar()
    {
        SceneManager.LoadScene("main");
    }

    public void salir()
    {
        Application.Quit();
    }


    private void cambioSentido()
    {
        clara1.SetBool("girarIzquierda", !clara1.GetBool("girarIzquierda"));
        clara2.SetBool("girarIzquierda", !clara2.GetBool("girarIzquierda"));

        oscura1.SetBool("girarDerecha", !oscura1.GetBool("girarDerecha"));
        oscura2.SetBool("girarDerecha", !oscura2.GetBool("girarDerecha"));

    }
}
