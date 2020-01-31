using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaObjetosScript : MonoBehaviour
{

    // Grupo de objetos
    public GameObject[] piezas;

    // Start is called before the first frame update
    void Start()
    {
        // Deja caer la primera pieza
        dejarCaerSiguiente();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dejarCaerSiguiente()
    {
        // Random Index
        int i = Random.Range(0, piezas.Length);

        // Spawn Group at current Position
        Instantiate(piezas[i],
                    transform.position,
                    Quaternion.identity);
    }

}
