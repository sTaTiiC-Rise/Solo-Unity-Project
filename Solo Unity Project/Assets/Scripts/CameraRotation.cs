using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    float verticalSpeed = -2.0f;
    // Update is called once per frame
    void Update()
    {
        float v = verticalSpeed * Input.GetAxis("Mouse X");

        transform.Rotate(0, -v, 0);
        
    }
}
