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

    // Cada cuántos segundos debe girar la aguja 'un segundo' de reloj
    public float tiempoMovimientoAguja;

    // Calculamos la relación segundo/ángulo para saber cuánto rotar
    // la aguja cada segundo. Cada 60 segundos debería rotar 360º.
    float anguloEnSegundos = 6;

    float startTime;

    void Start() {
        // Cogemos el tiempo inicial
        startTime = Time.time;
    }

    void Update() {
        // Calculamos el ángulo en grados para el giro
        float angulo = anguloEnSegundos*tiempoRestante;
        
        // Mostramos el tiempo
        text.text = Mathf.Round(tiempoRestante) + "s";

        // Cada 'segundo' moverá la aguja un segundo de reloj
        if (Time.time - startTime >= tiempoMovimientoAguja) {
            // Restamos el tiempo conforme avanza
            tiempoRestante -= 1;

            // Rotamos la aguja 
            aguja.transform.Rotate(0.0f, 0.0f, -anguloEnSegundos, Space.Self);

            // Actualizamos el valor de starttime
            startTime = Time.time;
        }
    }

    public void anyadirTiempo(int tiempo) {
        tiempoRestante += tiempo;
    }


    
}
