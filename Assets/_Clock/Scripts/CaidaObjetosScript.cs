using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaObjetosScript : MonoBehaviour
{

    // Grupo de objetos
    public GameObject[] piezas;

    // Index del objeto que vaya a caer
    int index = 0;
    int maxIndex;

    // Start is called before the first frame update
    void Start()
    {
        maxIndex = piezas.Length;
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
        //int i = Random.Range(0, piezas.Length);

        // Deja caer las primeras piezas en el orden en que están en el array 'piezas'
        if (index < maxIndex)
        {
            // Spawn Group at current Position
            Instantiate(piezas[index],
                        transform.position,
                        Quaternion.identity);

            index++;
        }
        // Ya ha salido una pieza de cada tipo, ahora son aleatorias
        else
        {
            int i = Random.Range(0, piezas.Length);
            Instantiate(piezas[i],
                        transform.position,
                        Quaternion.identity);
        }
    }

}
