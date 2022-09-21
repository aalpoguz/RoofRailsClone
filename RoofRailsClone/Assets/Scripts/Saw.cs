using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{


    private void Cut(Transform cutter)
    {
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
                piece.transform.localScale = new Vector3(transform.localScale.x, dist / 2, transform.localScale.z);
                piece.transform.rotation = transform.rotation;
                piece.transform.position = new Vector3(-(y - piece.transform.localScale.y), transform.position.y, transform.position.z);

                piece.AddComponent<Rigidbody>();


            }
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
                piece.transform.localScale = new Vector3(transform.localScale.x, dist / 2, transform.localScale.z);
                piece.transform.rotation = transform.rotation;
                piece.transform.position = new Vector3(y - piece.transform.localScale.y, transform.position.y, transform.position.z);

                piece.AddComponent<Rigidbody>();
            }
        }

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Saw"))
        {
            Cut(other.gameObject.transform);
        }
    }
}
