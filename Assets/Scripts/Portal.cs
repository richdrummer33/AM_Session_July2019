using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal otherPortal;

    bool canTeleport = true;
    
    void OnTriggerEnter(Collider otherCollider)
    {
        if(otherCollider.GetComponent<Rigidbody>() && canTeleport)
        {
            otherPortal.Teleport(otherCollider.gameObject, transform.InverseTransformPoint(otherCollider.transform.position), otherCollider.GetComponent<Rigidbody>().velocity);
        }
    }

    void OnTriggerExit(Collider otherCollider)
    {
        canTeleport = true;
    }

    public void Teleport(GameObject toTeleport, Vector3 localPos, Vector3 velocity)
    {
        canTeleport = false;

        Rigidbody rb = toTeleport.GetComponent<Rigidbody>();
        rb.AddForce(-2f * velocity, ForceMode.VelocityChange);

        toTeleport.transform.position = transform.TransformPoint(localPos);
    }
}
