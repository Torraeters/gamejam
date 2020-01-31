using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    // El tiempo (en s) inicial total para completar el nivel
    public float tiempoRestante;

    // Aguja del reloj
    public GameObject aguja;

    public Text text;

    // Calculamos la relación segundo/ángulo para saber cuánto rotar
    // la aguja cada segundo. Cada 15 segundos debería rotar 90º.
    float anguloEnSegundos = 360f/60f;

    void Update() {
        // Restamos el tiempo conforme avanza
        tiempoRestante -= Time.deltaTime;

        // Rotamos la aguja
        aguja.transform.Rotate(0.0f, 0.0f, anguloEnSegundos, Space.Self);

        // Mostramos el tiempo
        text.text = Mathf.Round(tiempoRestante) + "s";
    }

    public void anyadirTiempo(float tiempoExtra) {
        tiempoRestante += tiempoExtra;
    }
}
