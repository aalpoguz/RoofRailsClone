using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadpref : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("dead pieces");
            Destroy(this.gameObject);
        }
    }
}
