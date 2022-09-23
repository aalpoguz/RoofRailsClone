using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{

    public GameObject player;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("disabletrigger"))
        {
            this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.transform.GetChild(0).GetComponent<CapsuleCollider>().isTrigger = false;
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("abletrigger"))
        {
            this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.transform.GetChild(0).GetComponent<CapsuleCollider>().isTrigger = true;
            Destroy(other.gameObject);
        }
    }
}
