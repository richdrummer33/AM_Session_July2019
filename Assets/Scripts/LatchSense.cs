using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatchSense : MonoBehaviour
{
    public GameObject prefab;
    public Transform instantiationLocation;

    private void OnTriggerEnter(Collider otherCollider)
    {
        if(otherCollider.transform.parent == this.transform.parent) // Do Some Action
        {
            Instantiate(prefab, instantiationLocation.position, instantiationLocation.rotation);
        }
    }
}
