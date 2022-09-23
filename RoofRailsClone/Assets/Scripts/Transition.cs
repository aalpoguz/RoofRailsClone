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
            transform.GetChild(1).position = new Vector3(transform.position.x,-3.5f,transform.position.z);
            playerMovement.animator.SetBool("hang", true);
            playerMovement.animator.SetBool("run", false);
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
            transform.GetChild(1).position = new Vector3(transform.position.x,0,transform.position.z);
            playerMovement.animator.SetBool("hang", false);
            playerMovement.animator.SetBool("run", true);
            this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.transform.GetChild(0).GetComponent<CapsuleCollider>().isTrigger = true;
            Destroy(other.gameObject);
        }
    }
}
