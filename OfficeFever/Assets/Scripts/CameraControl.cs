using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject character;
    Vector3 distanceBetween;
    void Start()
    {
        distanceBetween = transform.position - character.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = character.transform.position + distanceBetween;
    }
}
