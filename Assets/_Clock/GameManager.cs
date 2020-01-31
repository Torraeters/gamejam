﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ------------------------
    // Atributos estaticos
    // ------------------------

    //att privado (_instancia)
    static private GameManager _instancia;

    //att publico (instancia) por el que accedemos
    static public GameManager instancia
    {
        // metodo get
        // se ejecuta al acceder por GameManager.instancia
        get
        {
            // si es la primera vez que accedemos a la instancia del GameManager,
            // no existira, y la crearemos
            if (_instancia == null)
            {
                // creamos un nuevo objeto llamado "_MiGameManager"
                GameObject go = new GameObject("_MiGameManager");

                // anadimos el script "GameManager" al objeto
                go.AddComponent<GameManager>();

                // guardamos en la instancia el objeto creado
                // debemos guardar el componente ya que _instancia es del tipo GameManager
                _instancia = go.GetComponent<GameManager>();

                // hacemos que el objeto no se elimine al cambiar de escena
                DontDestroyOnLoad(go);
            }

            // devolvemos la instancia
            // si no existia, en este punto ya la habra creado
            return _instancia;
        }

        // metodo set
        // no implementado para no permitir modificar la instancia "GameManager.instancia = x;"
    }

    // Constructor
    // Lo ocultamos el constructor para no poder crear nuevos objetos "sin control"
    protected GameManager() { }
}