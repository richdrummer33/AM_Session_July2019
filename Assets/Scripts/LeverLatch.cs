using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverLatch : MonoBehaviour
{
    private void OnTriggerStay(Collider otherCollider)
    {
        if(otherCollider.transform.parent == this.transform.parent) // Checking that the collider is part of this lever
        {
            Debug.Log("Collided!");
            GetComponent<Rigidbody>().AddForce(otherCollider.transform.right * 25f);
        }
    }
}