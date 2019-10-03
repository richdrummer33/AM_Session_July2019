using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringButtonSense : MonoBehaviour
{
    void OnTriggerEnter(Collider otherCollider)
    {
        if(otherCollider.transform.parent == transform.parent)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
