using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float forwardSpeed;
    public float horizontalSpeed;
    float lastTouchedX;
    private int firstTouch = 0;
    Rigidbody rb;

    public Animator animator;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float newX = 0;
        float touchDeltaX = 0;


        if (Input.touchCount > 0)
        {
            animator.SetBool("run", true);
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                firstTouch = 1;
                lastTouchedX = Input.GetTouch(0).position.x;
            }

            else if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                touchDeltaX = 5 * (Input.GetTouch(0).position.x - lastTouchedX) / Screen.width;
                lastTouchedX = Input.GetTouch(0).position.x;

            }

        }

        newX = transform.position.x + horizontalSpeed * touchDeltaX * Time.deltaTime;
        newX = Mathf.Clamp(newX, -4f, 4f);

        if (firstTouch == 1)
        {
            Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + forwardSpeed * Time.deltaTime);
            transform.position = newPosition;
        }
    }
}
