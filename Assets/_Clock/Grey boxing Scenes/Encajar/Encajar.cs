using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encajar : MonoBehaviour
{
    public string targetPieceType;
    public GameObject targetPiece;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.targetPiece != null)
        {
            // Si la pieza es del mismo tipo que el hueco
            if (this.targetPieceType == "1")
            {
                // Cálculamos distancia
                float xDistance = Mathf.Abs(this.targetPiece.transform.position.x - transform.position.x);
                float yDistance = Mathf.Abs(this.targetPiece.transform.position.y - transform.position.y);

                // Distancia mínima aceptable para que "encaje"
                float minDistance = 0.5f;

                // Si se cumple la dispancia mínima, encajar la pieza
                if (xDistance < minDistance && yDistance < minDistance)
                {
                    this.targetPiece.transform.position = transform.position;
                    this.targetPiece.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // Al detectar una colisión con una pieza, coger referencia del GameObject
        if (coll.gameObject.CompareTag("piece"))
        {
            this.targetPiece = coll.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        this.targetPiece = null;
    }
}
