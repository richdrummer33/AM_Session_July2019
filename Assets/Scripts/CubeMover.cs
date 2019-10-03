using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) == true)
        {
            transform.position = transform.position + transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            transform.position = transform.position - transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.position = transform.position - transform.right * speed;
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.position = transform.position + transform.right * speed;
        }
    }
}