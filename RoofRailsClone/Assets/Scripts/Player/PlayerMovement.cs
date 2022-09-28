using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    public CollectDiamonds collectDiamonds;
    public float forwardSpeed;
    public float horizontalSpeed;
    float lastTouchedX;
    private int firstTouch = 0;
    Rigidbody rb;
    public int mScore;
    public GameObject finishScreen;
    public TextMeshProUGUI score;
    public TextMeshProUGUI multipliedScore;
    public GameObject rigged;
    public GameObject cyl;


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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("X20Box"))
        {
            transform.GetChild(1).position = new Vector3(transform.position.x,transform.GetChild(0).position.y - 0.1f, transform.position.z);
            Destroy(cyl.gameObject);
            forwardSpeed = 0;
            horizontalSpeed = 0;
            animator.SetBool("dancing", true);
            finishScreen.SetActive(true);
            score.text = collectDiamonds.score.ToString();
            Debug.Log("game over ");
            mScore = 20 * collectDiamonds.score;
            multipliedScore.text = mScore.ToString();
        }

        if (other.gameObject.CompareTag("X15Box"))
        {
            transform.GetChild(1).position = new Vector3(transform.position.x, transform.GetChild(0).position.y - 0.1f, transform.position.z);
            Destroy(cyl.gameObject);
            forwardSpeed = 0;
            horizontalSpeed = 0;
            animator.SetBool("dancing", true);
            finishScreen.SetActive(true);
            score.text = collectDiamonds.score.ToString();
            Debug.Log("game over ");
            mScore = 15 * collectDiamonds.score;
            multipliedScore.text = mScore.ToString();
        }

    }
}
