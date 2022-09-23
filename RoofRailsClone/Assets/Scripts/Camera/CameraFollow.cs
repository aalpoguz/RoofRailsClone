using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private Vector3 offset;
    private Vector3 newPosition;

    [SerializeField][Range(0, 3)] private float lerpValue;

    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CamFollow();
    }

    public void CamFollow()
    {
        newPosition = Vector3.Lerp(transform.position, playerTransform.position + offset, lerpValue * Time.deltaTime);
        transform.position = newPosition;
    }
}
