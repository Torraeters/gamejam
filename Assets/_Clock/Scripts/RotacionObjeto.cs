using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionObjeto : MonoBehaviour
{
    private int velocity = 10;
    public float velocityDown = -0.2f;
    private int grads = 45;

    public Objeto objeto;

    // Start is called before the first frame update
    void Start()
    {
        objeto = GetComponentsInChildren<Objeto>()[0];

    }

    // Update is called once per frame
    void Update()
    {
        //movimientoBajada();
        moverGear();
        if (objeto.tipoPieza == objeto.tiposPiezas[2])
        {
            girarGear();
        }
    }

    //---------------------------------------------------------------------------------------------
    // Funciones
    //---------------------------------------------------------------------------------------------
    //Control de la rotacion de l objeto
    private void girarGear()
    {
        //Giro izquierda
        if (Input.GetButtonDown("Fire1") && gameObject.GetComponent<Rigidbody2D>().constraints != RigidbodyConstraints2D.FreezePosition)
        {
            transform.Rotate(0, 0, grads);
            if (objeto.angulo == 180)
            {
                objeto.angulo = -135;
            }
            else
            {
                objeto.angulo = objeto.angulo + grads;
            }
        }

        // Giro Derecha
        if (Input.GetButtonDown("Fire2") && gameObject.GetComponent<Rigidbody2D>().constraints != RigidbodyConstraints2D.FreezePosition)
        {
            transform.Rotate(0, 0, -grads);

            if (objeto.angulo == -180)
            {
                objeto.angulo = 135;
            }
            else
            {
                objeto.angulo = objeto.angulo - grads;
            }
        }
    }

    // Control del moviminento horizontal del objeto
    private void moverGear()
    {

        if (Input.GetAxis("Horizontal") > 0 && gameObject.GetComponent<Rigidbody2D>().constraints != RigidbodyConstraints2D.FreezePosition)
        {
            transform.Translate(velocity * Time.deltaTime, 0, 0, Space.World);
        }
        if (Input.GetAxis("Horizontal") < 0 && gameObject.GetComponent<Rigidbody2D>().constraints != RigidbodyConstraints2D.FreezePosition)
        {
            transform.Translate(-velocity * Time.deltaTime, 0, 0, Space.World);
        }

    }

    //Movimiento automatico de bajada del objeto
    private void movimientoBajada()
    {

        transform.Translate(0, velocityDown * Time.deltaTime, 0, Space.World);
    }
}
