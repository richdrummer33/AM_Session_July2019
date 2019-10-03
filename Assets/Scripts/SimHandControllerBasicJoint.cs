using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandControllerBasicJoint : MonoBehaviour
{
    public float moveSpeed = 2f;

    public float rotateSpeed = 100f;

    public GameObject collidingObject;

    public GameObject heldObject;

    public Animator anim;

    public float breakForce = 5000f;

    #region Collisions

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grabbable")
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
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            anim.SetBool("Closed", true);
            GrabObject();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            anim.SetBool("Closed", false);
            ReleaseObject();
        }

        if(Input.GetKeyDown(KeyCode.Mouse0)) // Left mouse button - Interact
        {
            if(heldObject != null) // We're holding something
            {
                if(heldObject.GetComponent<InteractableObject>()) // Check if inherits from InteractableObject
                {
                    heldObject.GetComponent<InteractableObject>().InteractStart();
                }
                // heldObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver); --> Replaced by "heldObject.GetComponent<InteractableObject>().InteractStart();"
            }
        }

        #region Movement Functions

        if (Input.GetKey(KeyCode.W)) // Forward
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S)) // Backeard
        {
            transform.position -= transform.forward * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.A)) // Left
        {
            transform.position -= transform.right * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D)) // Right
        {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.Q)) // Up
        {
            transform.position += transform.up * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.E)) // Down
        {
            transform.position -= transform.up * Time.deltaTime * moveSpeed;
        }

        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed, Space.World);
        transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed, Space.Self);

        #endregion
    }

    #region Grab and Release

    private void GrabObject() 
    {
        if (collidingObject != null)
        {
            // collidingObject.SendMessage("GrabAction", this.transform, SendMessageOptions.DontRequireReceiver); // For scripted levers (and potentially other things!)

            if(collidingObject.GetComponent<InteractableObject>())
            {
                collidingObject.GetComponent<InteractableObject>().GrabAction(this.transform); // Replaces SendMessage
            }

            if (collidingObject.GetComponent<Rigidbody>()) // If object has a rigidbody, form a joint between the hand and the object
            {
                FixedJoint joint = gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = collidingObject.GetComponent<Rigidbody>();
                joint.breakForce = breakForce;
            }

            heldObject = collidingObject;
        }
    }

    private void ReleaseObject()
    {
        if (heldObject != null)
        {
            // heldObject.SendMessage("ReleaseAction", SendMessageOptions.DontRequireReceiver); // For scripted levers (and potentially other things!)

            if(heldObject.GetComponent<InteractableObject>())
            {
                heldObject.GetComponent<InteractableObject>().ReleaseAction(); // Replaces SendMessage
            }

            if (GetComponent<FixedJoint>()) // If heldObject has a rigidbody, then it is joined to our hand - break the joint
            {
                Destroy(GetComponent<FixedJoint>());
            }
        }
    }

    #endregion
}
