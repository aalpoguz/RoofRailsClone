using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{

    public GameObject player;
    public PlayerMovement playerMovement;

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

        if (other.gameObject.CompareTag("disableAnimation"))
        {
            playerMovement.animator.SetBool("hang", true);
            playerMovement.animator.SetBool("run", false);
            transform.GetChild(1).position = new Vector3(transform.position.x, transform.GetChild(0).position.y - 4f, transform.position.z);
        }

        if (other.gameObject.CompareTag("ableAnimation"))
        {
            playerMovement.animator.SetBool("hang", false);
            playerMovement.animator.SetBool("run", true);
            transform.GetChild(1).position = new Vector3(transform.position.x, transform.GetChild(0).position.y - 1.86f, transform.position.z);

        }

        //-1.86f 
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
