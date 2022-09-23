using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCylinder : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            Debug.Log("degdi");
            transform.localScale = new Vector3(transform.localScale.x, +transform.localScale.y + 0.5f, transform.localScale.z);
            Destroy(other.gameObject);
        }
    }

}
