using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Contador : MonoBehaviour
{
    // El tiempo (en s) inicial total para completar el nivel
    public float tiempoRestante;

    // Aguja del reloj
    public GameObject aguja = null;

    public Scene currentScene;


    public Text text;

    // Cada cuántos segundos debe girar la aguja 'un segundo' de reloj
    public float tiempoMovimientoAguja;

    // Calculamos la relación segundo/ángulo para saber cuánto rotar
    // la aguja cada segundo. Cada 60 segundos debería rotar 360º.
    float anguloEnSegundos = 6;

    public float startTime;
    public float elapsedTime;

    public bool stop = false;

    void Start()
    {
        // Cogemos el tiempo inicial
        startTime = Time.timeSinceLevelLoad;
        currentScene.name = "preload";
        //Debug.Log("start");
    }

    void Update()
    {
        if(GetComponent<GameManager>().youWin) elapsedTime = Time.time;
        else elapsedTime = Time.timeSinceLevelLoad;
        //Debug.Log(Time.timeSinceLevelLoad - startTime);
        if (currentScene.name != "menuPrincipal" && currentScene.name != "preload" && aguja !=null)
        {
            // Mostramos el tiempo
            //text.text = Mathf.Round(tiempoRestante) + "s";

            // Cada 'segundo' moverá la aguja un segundo de reloj
            if (elapsedTime - startTime >= tiempoMovimientoAguja && stop == false)
            {
                // Restamos el tiempo conforme avanza
                tiempoRestante -= 1;

                // Rotamos la aguja 
                aguja.transform.Rotate(0.0f, 0.0f, -anguloEnSegundos, Space.Self);

                // Actualizamos el valor de starttime
                startTime = elapsedTime;
            }

            if (tiempoRestante <= 0)
            {
                stopMovimientoAguja();
            }
        }
    }

    // Función que añade tiempo al contador para cuando el jugador acierta, y rota la aguja
    // conforme al tiempo que se haya añadido
    public void anyadirTiempo(int tiempo)
    {
        tiempoRestante += tiempo;
        if (tiempoRestante > 60)
        {
            tiempoRestante = 60;
            aguja.transform.Rotate(0.0f, 0.0f, tiempo, Space.Self);
        }
        else
        {
            aguja.transform.Rotate(0.0f, 0.0f, anguloEnSegundos * tiempo, Space.Self);
        }
    }

    public void stopMovimientoAguja()
    {
        stop = true;
        startTime = 0f;
    }

    // Función para cambiar la velocidad de la aguja
    public void cambiarTiempoMovimientoAguja(float nuevoTiempoMovimientoAguja)
    {
        tiempoMovimientoAguja = nuevoTiempoMovimientoAguja;
    }
    
    public void initContador() {
        startTime = 0f;
        tiempoRestante = 60f;
    }

}
