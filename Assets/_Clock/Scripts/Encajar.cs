using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encajar : MonoBehaviour
{
    public string targetPieceType;
    public GameObject targetPiece;
    public bool isFitIn = false;
    public bool atornillado;
    private float targetPieceRotation;
    GameObject caidaObjetos;
    CaidaObjetosScript caidaObjetosScript;
    public GameObject particulas;

    // Start is called before the first frame update
    void Start()
    {
        this.targetPieceRotation = gameObject.transform.rotation.z;
        caidaObjetos = GameObject.Find("CaidaObjetos");
        caidaObjetosScript = caidaObjetos.GetComponent<CaidaObjetosScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.targetPiece != null)
        {
            string pieceType = targetPiece.GetComponent<Objeto>().tipoPieza;

            // Si la pieza es del mismo tipo que el hueco
            if (this.targetPieceType == pieceType)
            {
                // Cálculamos distancia
                float xDistance = Mathf.Abs(this.targetPiece.transform.position.x - transform.position.x);
                float yDistance = Mathf.Abs(this.targetPiece.transform.position.y - transform.position.y);
                float angleDiff = Mathf.Abs(this.targetPieceRotation - this.targetPiece.transform.rotation.z);

                // Distancia mínima aceptable para que "encaje"
                float minDistance = 2f;

                // Si se cumple la dispancia mínima, encajar la pieza
                if (xDistance < minDistance && yDistance < minDistance && angleDiff < 0.2)
                {
                    this.targetPiece.transform.parent.gameObject.transform.position = transform.position;
                    particulas.GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Particulas";
                    particulas.GetComponent<ParticleSystem>().Play();
                    this.targetPiece.transform.parent.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                    this.targetPiece.GetComponent<Animator>().SetBool("isWorking", true);
                    if (this.targetPiece.tag == "piece")
                    {
                        caidaObjetosScript.dejarCaerSiguiente();
                        GameObject.Find("GameManager(Clone)").GetComponent<Contador>().anyadirTiempo(5);
                    }
                    this.targetPiece.tag = "Untagged";
                    isFitIn = true;
                    atornillado = true;
                    this.enabled = false;
                    targetPiece.GetComponent<Collider2D>().enabled = false;

                    if (gameObject.GetComponentInChildren<Animator>() !=null){
                        gameObject.GetComponentInChildren<Animator>().SetBool("points", true);
                        gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    }
                    //gameObject.SetActive(false);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // Al detectar una colisión con una pieza, coger referencia del GameObject
        if (coll.gameObject.CompareTag("piece") || coll.gameObject.CompareTag("tornillo"))
        {
            this.targetPiece = coll.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        this.targetPiece = null;
    }
}
