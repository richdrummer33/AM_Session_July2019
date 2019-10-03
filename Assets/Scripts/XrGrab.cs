using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrGrab : MonoBehaviour
{
    #region Grab Params

    public GameObject heldObject;

    public GameObject collidingObject;

    public Animator anim;
    
    private bool gripHeld = false;

    public string gripAxisName;

    public string triggerAxisName;

    private bool triggerHeld = false;

    private FixedJoint grabJoint;

    #endregion

    #region Throw Params

    private Vector3 throwVelocity;

    private Vector3 lastPosition;

    #endregion

    // Update is called once per frame
    void Update()
    {
        #region Grab
        if (Input.GetAxis(gripAxisName) > 0.5f && gripHeld == false) // Grab
        {
            anim.SetBool("Closed", true);
            Debug.Log("Right grip pressed");
            GrabObject(collidingObject);
            gripHeld = true;
        }
        else if(Input.GetAxis(gripAxisName) < 0.5f && gripHeld == true)
        {
            anim.SetBool("Closed", false);
            Debug.Log("Right grip released");
            ReleaseObject();
            gripHeld = false;
        }
        #endregion

        #region Interact

        if(Input.GetAxis(triggerAxisName) > 0.5f && triggerHeld == false)
        {
            if (heldObject != null)
            {
                heldObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver); // Calls the function in any and all scripts attached to heldObject of the name "Interact"
            }

            triggerHeld = true; // Comment out this line for a fun effect
        }
        else if(Input.GetAxis(triggerAxisName) < 0.5f)
        {
            triggerHeld = false;
        }

        #endregion

        #region Throw

        throwVelocity = (transform.position - lastPosition) / Time.deltaTime;

        lastPosition = transform.position;

        #endregion
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.GetComponent<Rigidbody>())
        {
            collidingObject = otherCollider.gameObject;
        }
    }

    private void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.GetComponent<Rigidbody>() && collidingObject) // MAke sure we have 
        {
            if (otherCollider.transform == collidingObject.transform)
            {
                collidingObject = null;
            }
        }
    }

    public void GrabObject(GameObject objectToGrab)
    {
        if (objectToGrab)
        {
            if (objectToGrab.GetComponent<Rigidbody>())
            {
                heldObject = objectToGrab;

                grabJoint = gameObject.AddComponent<FixedJoint>();

                grabJoint.connectedBody = heldObject.GetComponent<Rigidbody>();

                grabJoint.breakForce = 1000f;
            }
        }
    }

    private void ReleaseObject()
    {
        if (heldObject != null)
        {
            Destroy(grabJoint);

            heldObject.GetComponent<Rigidbody>().velocity = throwVelocity;

            heldObject = null;
        }
    }
}
