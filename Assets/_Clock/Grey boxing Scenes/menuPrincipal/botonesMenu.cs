using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonesMenu : MonoBehaviour
{
    public Animator controladorAnim;


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
        controladorAnim.SetBool("muestraPlay", false);
    }
}
