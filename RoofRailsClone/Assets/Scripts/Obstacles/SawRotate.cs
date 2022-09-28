using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotate : MonoBehaviour
{
    float speed = 1.5f;
    void Update()
    {
      
    #region Saw rotation 
        transform.Rotate(0,200 * speed * Time.deltaTime ,0);
    #endregion
       
    }
}
