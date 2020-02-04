using System.Collections;
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
    public bool youWin = false;

    public Scene currentScene;

    // Miramos si se ha pausado el juego
    private bool isPaused = false;

    // Lista de objetos de la pantalla tipo Hole
    private GameObject[] holesList;

    //att publico (instancia) por el que accedemos
    public static GameManager instance = null;

    public GameObject gameOverPanel;
    public GameObject winPanel;
    public GameObject pauseGamePanel;

    public Button botonMenu;
    public Button botonReplay;

    public Button botonMenuWin;
    public Button botonNextLevel;

    public int contadorNiveles = 0;
    public bool nivelCargado;
    Musica musica;

    bool dejarCaer;

    GameObject[] piezas;
    GameObject[] sfx;

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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentScene = SceneManager.GetActiveScene();
        musica = GameObject.Find("Musica").GetComponent<Musica>();
        if (currentScene.name != "menuPrincipal" && currentScene.name != "preload")
        {
            nivelCargado = false;
            this.initGame();
            contador.currentScene = currentScene;
            if (!youWin)
            {
                contador.startTime = 0f;
                contador.stop = false;
                contador.tiempoRestante = 60f;
                contador.aguja.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
            if (!musica.isPlaying) musica.play();
        }
        if (currentScene.name == "menuPrincipal") musica.stop();

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
        contador = GetComponent<Contador>();
        contador.aguja = GameObject.Find("Aguja_larga");
        holesList = GameObject.FindGameObjectsWithTag("hole");
        botonMenu.onClick.AddListener(botonMenuPulsado);
        botonReplay.onClick.AddListener(botonReplayPulsado);

        botonMenuWin.onClick.AddListener(botonMenuWinPulsado);
        botonNextLevel.onClick.AddListener(botonNextLevelPulsado);
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
                //contador.anyadirTiempo(tiempo);
                esLaPrimeraVez = false;
            }
            winLostGame();
        }

        if (dejarCaer)
        {
            int moveSpeed = 7;
            sfx[0].transform.Translate(0, -Time.deltaTime * moveSpeed, 0, Space.World);
            for (int i = 0; i < piezas.Length; i++)
            {
                piezas[i].transform.parent.transform.Translate(0, -Time.deltaTime * moveSpeed, 0, Space.World);
            }
        }
    }

    private void pauseGame()
    {
        if (isPaused)
        {
            pauseGamePanel.GetComponent<Animator>().SetBool("isOpen", true);
            isPaused = false;
            Time.timeScale = 0;
        }
        else
        {
            pauseGamePanel.GetComponent<Animator>().SetBool("isOpen", false);
            isPaused = true;
            Time.timeScale = 1;
        }
    }

    private void winLostGame()
    {
        //Debug.Log(contador.tiempoRestante);
        if (contador.tiempoRestante > 0 && nivelCargado == false)
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
            piezas = GameObject.FindGameObjectsWithTag("piezaDone");
            sfx = GameObject.FindGameObjectsWithTag("sfxpieza");

            for (int i = 0; i < piezas.Length; i++)
            {
                dejarCaer = true;
                Debug.Log(piezas[i].transform.parent.name);
                piezas[i].transform.parent.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                piezas[i].transform.parent.transform.GetComponent<RotacionObjeto>().enabled = false;
            }

            // Activamos animacion ganar
            contadorNiveles++;
            StartCoroutine(caenEngranajes());
        }
        else if (contador.tiempoRestante == 0)
        {
            // Aquí se ha de poner lo que queremos que haga cuando se haya perdido
            Debug.Log("Has perdido");
            contador.tiempoRestante = -1;
            gameOverPanel.GetComponent<Animator>().SetBool("isOpen", true);

        }
    }

    // Para el panel de game over
    private void botonMenuPulsado()
    {
        // Cargar la escena del menu
        gameOverPanel.GetComponent<Animator>().SetBool("isOpen", false);
        SceneManager.LoadScene("menuPrincipal");
    }

    private void botonReplayPulsado()
    {
        youWin = false;
        gameOverPanel.GetComponent<Animator>().SetBool("isOpen", false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private void botonNextLevelPulsado()
    {
        winPanel.GetComponent<Animator>().SetBool("isOpen", false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    // Para el panel de win
    private void botonMenuWinPulsado()
    {
        // Cargar la escena del menu
        winPanel.GetComponent<Animator>().SetBool("isOpen", false);
        SceneManager.LoadScene("menuPrincipal");
    }

    private void cargarSiguienteNivel()
    {
        SceneManager.LoadScene("Nivel " + contadorNiveles);
    }

    IEnumerator caenEngranajes()
    {
        nivelCargado = true;
        yield return new WaitForSeconds(1.5f);
        dejarCaer = false;
        cargarSiguienteNivel();
    }
}
