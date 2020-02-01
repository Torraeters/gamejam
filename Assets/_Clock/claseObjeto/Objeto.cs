using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    public string[] tiposPiezas = new string[] { "engranajeConTornillo", "engranajeSinTornillo", "engranajeConAcople", "triangularT", "circularT", "hexagonalT" };

    public int angulo;

    public float posicionX;
    public float posicionY;

    public string tipoPieza;


    // Start is called before the first frame update
    void Start()
    {
        angulo = 0;
        tipoPieza = tiposPiezas[1];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
