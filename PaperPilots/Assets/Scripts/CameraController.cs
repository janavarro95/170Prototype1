using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool follow;
    public GameObject followObject;

    private Vector3 initialOffset;

    void Start()
    {
        initialOffset = transform.position - followObject.transform.position;
    }

    void LateUpdate()
    {
        if(follow)
            transform.position = followObject.transform.position + initialOffset;
    }
}