using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject Piece;


    public Transform right;
    public Transform left;

    private void Start()
    {
    }
    private void Lava(Transform fires)
    {
        float y = transform.localScale.y;
        y = transform.position.x;


        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 1.1f, transform.localScale.z);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);


        Instantiate(Piece, right.position, Quaternion.Euler(0, 0, 90));
        Instantiate(Piece, left.position, Quaternion.Euler(0, 0, 90));


        // GameObject piecesL = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        // GameObject piecesR = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        // piecesL.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 7, transform.localScale.z);

        // piecesL.transform.rotation = transform.rotation;
        // piecesL.transform.position = new Vector3(-(y - piecesL.transform.localScale.y), transform.position.y, transform.position.z);

        // piecesR.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 7, transform.localScale.z);

        // piecesR.transform.rotation = transform.rotation;
        // piecesR.transform.position = new Vector3(y - piecesR.transform.localScale.y, transform.position.y, transform.position.z);

        // piecesL.AddComponent<Rigidbody>();
        // piecesR.AddComponent<Rigidbody>();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fire"))
        {
            Lava(other.gameObject.transform);
        }

    }
}
