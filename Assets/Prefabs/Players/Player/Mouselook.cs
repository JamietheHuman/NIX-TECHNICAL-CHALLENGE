using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselook : MonoBehaviour
{
    public float MouseSensitivity = 100f;
    public Transform playerbody;
    float xRotation = 0f; 
    void Start()
    {
        Screen.lockCursor = true;
    }

    void Update()
    {
        float Mx = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float My = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        xRotation -= My;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerbody.Rotate(Vector3.up * Mx);
    }
}
