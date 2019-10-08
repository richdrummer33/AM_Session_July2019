using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Must be attached to the camera of the mirror (the mirror surface should be the cam's parent)
/// </summary>
[ExecuteInEditMode]
public class MirrorReflect : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 phoneToMirror = transform.position - Camera.main.transform.position; // Vector from the AR camera to the mirror's camera

        Vector3 reflectinDirection = Vector3.Reflect(phoneToMirror, transform.parent.up); // transform.parent is the mirror plane, and .up is the "normal" of the mirror's surface

        transform.rotation = Quaternion.LookRotation(reflectinDirection); // This is similar to the LookAt function - converts a direction into a rotation "type" i.e. a quaternion
    }
}
