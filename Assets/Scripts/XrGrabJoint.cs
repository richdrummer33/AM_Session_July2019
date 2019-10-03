using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrGrabJoint : MonoBehaviour
{
    public GameObject collidingObject;

    public GameObject heldObject;

    public Animator anim;

    public string gripInputName;

    private bool gripHeld = false;

    private Vector3 throwVelocity;

    private Vector3 lastPosition;

    private FixedJoint grabJoint; // This joint will be created on the hand and will connect to the grabbed object

    public string triggerInputName;

    public bool triggerHeld = false; // Prevent "full auto" action 

    #region Collisions

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grabbable") // Make sure we don't grab non-grabbable objects!!! Also, we only want to grab Rigidbodies
        {
            collidingObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == collidingObject)
        {
            collidingObject = null;
        }
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        #region Grab and Release

        if (Input.GetAxis(gripInputName) > 0.5f && gripHeld == false)
        {
            GrabObject();
            gripHeld = true;
            anim.SetBool("Closed", true);
        }
        else if (Input.GetAxis(gripInputName) < 0.5f && gripHeld == true)
        {
            ReleaseObject();
            gripHeld = false;
            anim.SetBool("Closed", false);
        }

        #endregion

        #region Interact

        if(Input.GetAxis(triggerInputName) > 0.5f && triggerHeld == false) // Trigger pulled
        {
            if (heldObject != null) // Got to make sure we're holding something before interacting!
            {
                //heldObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver); // General way to initialize an interaction with any GameObject that has a script containing a function called Interact()

                if (heldObject.GetComponent<InteractableObject>())
                {
                    heldObject.GetComponent<InteractableObject>().InteractStart();
                }                
            }

            triggerHeld = true; 
        }
        else if(Input.GetAxis(triggerInputName) < 0.5f && triggerHeld == true) // Trigger Released
        {
            if (heldObject != null)
            {
                if (heldObject.GetComponent<InteractableObject>())
                {
                    heldObject.GetComponent<InteractableObject>().InteractEnd();
                }
            }

            triggerHeld = false; 
        }

        #endregion

        #region Throw Calcs

        throwVelocity = (transform.position - lastPosition) / Time.deltaTime; // Direction and magnitude in meters per second

        lastPosition = transform.position;

        #endregion
    }

    #region Grab and Release

    private void GrabObject()
    {
        if (collidingObject != null)
        {
            heldObject = collidingObject; // Holds a reference to the held object (so it can be released!)

            // collidingObject.SendMessage("GrabAction", this.transform, SendMessageOptions.DontRequireReceiver);

            if(collidingObject.GetComponent<InteractableObject>())
            {
                collidingObject.GetComponent<InteractableObject>().GrabAction(this.transform); // Replaces SendMessage
            }

            if (collidingObject.GetComponent<Rigidbody>())
            {
                grabJoint = gameObject.AddComponent<FixedJoint>(); // This line creates the joint 

                grabJoint.connectedBody = heldObject.GetComponent<Rigidbody>(); // This makes the grab happen!

                grabJoint.breakForce = 1000f; // Force required to make the object break away from the hand (do you enven lift?)

                grabJoint.breakTorque = 1000f;

                heldObject.transform.SetParent(transform); // Makes the heldobject a child to minimize physics movement jitter 
            }
        }
    }

    private void ReleaseObject()
    {
        if (heldObject != null)
        {
            //heldObject.SendMessage("ReleaseAction", SendMessageOptions.DontRequireReceiver);

            if (collidingObject.GetComponent<InteractableObject>())
            {
                collidingObject.GetComponent<InteractableObject>().ReleaseAction();
            }

            if (heldObject.GetComponent<Rigidbody>())
            {
                Destroy(grabJoint); // Drop the object!

                heldObject.GetComponent<Rigidbody>().velocity = throwVelocity; // Apply the hand's velocity to the object

                heldObject.transform.SetParent(null);
            }

            heldObject = null; // No longer holding this!!
        }
    }

    private void OnJointBreak(float breakForce) // This function gets called ("triggered") automatically (by monobehavior) when the joint breaks due to excessive force
    {
        heldObject.transform.SetParent(null);

        heldObject = null; // No longer holding this!!
    }

    #endregion
}
