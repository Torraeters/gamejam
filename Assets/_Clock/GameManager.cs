﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ------------------------
    // Atributos estaticos
    // -----------------------

    Contador contador;
    GameObject cont;
    Encajar encajar;
    GameObject hole;
    atornillar atornillar;
    GameObject tornillo;

    // tiempo que se añade cuando se encaja una pieza
    public int tiempo = 5;
    private bool esLaPrimeraVez = true;
    private bool youWin = false;

    public Scene currentScene;

    // Miramos si se ha pausado el juego
    private bool isPaused = false;

    // Lista de objetos de la pantalla tipo Hole
    private GameObject[] holesList;

    //att publico (instancia) por el que accedemos
    public static GameManager instance = null;

    public GameObject gameOverPanel;
    public GameObject winPanel;

    public Button botonMenu;
    public Button botonReplay;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;

            // Get different component managers
            //uiManager = GetComponent<UIManager>();

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);

            //Call the InitGame function to initialize the game
            //InitGame();
        }
        else if (instance != this) //If instance already exists and it's not this:
        {
            DestroyImmediate(gameObject); //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        }
    }


    // Constructor
    // Lo ocultamos para no poder crear nuevos objetos "sin control"
    protected GameManager() { }

    void Start()
    {

    }

    void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name != "menuPrincipal" && currentScene.name != "preload")
        {
            this.initGame();
        }

    }

    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // called first
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    public void initGame()
    {
        hole = GameObject.Find("engranajeConAcopleAgujero");
        encajar = hole.GetComponent<Encajar>();
        cont = GameObject.Find("Main Camera");
        contador = cont.GetComponent<Contador>();
        holesList = GameObject.FindGameObjectsWithTag("hole");


        botonMenu.onClick.AddListener(botonMenuPulsado);
        botonReplay.onClick.AddListener(botonReplayPulsado);
    }

    void Update()
    {

        if (currentScene.name != "menuPrincipal" && currentScene.name != "preload")
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                pauseGame();
            }
            if (encajar.isFitIn && esLaPrimeraVez)
            {
                contador.anyadirTiempo(tiempo);
                esLaPrimeraVez = false;
            }
            winLostGame();
        }
    }

    private void pauseGame()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 0;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 1;
        }
    }

    private void winLostGame()
    {
        //Debug.Log(contador.tiempoRestante);
        if (contador.tiempoRestante > 0)
        {

            foreach (GameObject holeElement in holesList)
            {
                Encajar encajar = holeElement.GetComponent<Encajar>();
                if (!encajar.isFitIn)
                {
                    return;
                }
            }

            // Aquí se ha de poner lo que queremos que haga cuando se haya ganado
            Debug.Log("Has ganado");

            youWin = true;

            // Activamos animacion ganar
            winPanel.GetComponent<Animator>().SetBool("isOpen", true);

        }
        else if (contador.tiempoRestante == 0 )
        {
            // Aquí se ha de poner lo que queremos que haga cuando se haya perdido
            Debug.Log("Has perdido");
            contador.tiempoRestante = -1;
            gameOverPanel.GetComponent<Animator>().SetBool("isOpen", true);

        }
    }

    private void botonMenuPulsado()
    {
        // Cargar la escena del menu
    }

    private void botonReplayPulsado()
    {
        gameOverPanel.GetComponent<Animator>().SetBool("isOpen", false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
