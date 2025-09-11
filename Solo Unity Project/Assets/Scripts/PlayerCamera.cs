using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    float Speed = -2.0f;
    // Update is called once per frame
    void Update()
    {
        float v = Speed * Input.GetAxis("Mouse Y");

        transform.Rotate(v, 0, 0);

    }
}
