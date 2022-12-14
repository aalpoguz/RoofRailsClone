using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    GameObject cuttedPiece1;
    GameObject cuttedPiece2;

    
    private void Cut(Transform cutter)
    {
        //left side
        if (cutter.transform.position.x < 0)
        {
            float y = transform.localScale.y;
            y -= transform.position.x;
            float dist = y + cutter.position.x;

            if (dist / 2 > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - dist / 2, transform.localScale.z);
                transform.position = new Vector3(transform.position.x + dist / 2, transform.position.y, transform.position.z);

                GameObject piece = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                cuttedPiece1 = piece;
                piece.transform.localScale = new Vector3(transform.localScale.x, dist / 2, transform.localScale.z);
                piece.transform.rotation = transform.rotation;
                piece.transform.position = new Vector3(-(y - piece.transform.localScale.y), transform.position.y, transform.position.z);

                piece.AddComponent<Rigidbody>();
                StartCoroutine(piecesDestroy());


            }
            StartCoroutine(SawPosition());
           
        }

        else
        {
            //right side

            float y = transform.localScale.y;
            y += transform.position.x;
            float dist = y - cutter.position.x;

            if (dist / 2 > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - dist / 2, transform.localScale.z);
                transform.position = new Vector3(transform.position.x - dist / 2, transform.position.y, transform.position.z);

                GameObject piece = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                cuttedPiece2 = piece;
                piece.transform.localScale = new Vector3(transform.localScale.x, dist / 2, transform.localScale.z);
                piece.transform.rotation = transform.rotation;
                piece.transform.position = new Vector3(y - piece.transform.localScale.y, transform.position.y, transform.position.z);

                piece.AddComponent<Rigidbody>();
                StartCoroutine(piecesDestroy());
            }

            StartCoroutine(SawPosition());
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Saw"))
        {
            Cut(other.gameObject.transform);
        }
    }

    IEnumerator SawPosition()
    {
        yield return new WaitForSeconds(0.15f);
        this.gameObject.transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
    }

    IEnumerator piecesDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(cuttedPiece1);
        Destroy(cuttedPiece2);

    }


}
