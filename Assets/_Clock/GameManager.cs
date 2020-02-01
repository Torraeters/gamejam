using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ------------------------
    // Atributos estaticos
    // -----------------------

    Contador contador;
    GameObject cont;
    Encajar encajar;
    GameObject hole;

    // tiempo que se añade cuando se encaja una pieza
    public int tiempo = 5;
    private bool esLaPrimeraVez = true;

    // Miramos si se ha pausado el juego
    private bool isPaused = false;

    //att privado (_instancia)
    static private GameManager _instancia;

    // Lista de objetos de la pantalla tipo Hole
    private GameObject[] holesList;

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
                GameObject go = new GameObject("GameManager");

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

    void Start()
    {
        hole = GameObject.Find("engranajeConAcopleAgujero");
        encajar = hole.GetComponent<Encajar>();
        cont = GameObject.Find("Main Camera");
        contador = cont.GetComponent<Contador>();
        holesList = GameObject.FindGameObjectsWithTag("hole");
    }

    void Update()
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
        if (contador.tiempoRestante != 0)
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
        }else if(contador.tiempoRestante == 0)
        {
            // Aquí se ha de poner lo que queremos que haga cuando se haya perdido
            Debug.Log("Has perdido");
        }
    }
}
