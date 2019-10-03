using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public virtual void InteractStart()
    {
        Debug.Log("Interaction started");
    }

    public virtual void InteractEnd()
    {
        Debug.Log("Interaction ended");
    }

    public virtual void GrabAction(Transform hand)
    {
        Debug.Log("Grabbing action started");
    }

    public virtual void ReleaseAction()
    {
        Debug.Log("Release action started");
    }
}
