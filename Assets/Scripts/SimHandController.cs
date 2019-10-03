using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimHandController : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed = 20f;

    public GameObject heldObject;

    public GameObject collidingObject;

    public Animator anim;

    public GameObject fireballPrefab;

    public float fireForce = 15f;

    public Text uiText;

    private int numFired = 0;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        #region Grabbing

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            anim.SetBool("Closed", true);
            GrabObject(collidingObject);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            anim.SetBool("Closed", false);
            ReleaseObject();
        }

        // Fire a fireball with left mouse button!
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject newFireball = Instantiate(fireballPrefab, transform.position, transform.rotation);

            newFireball.GetComponent<Rigidbody>().AddForce(transform.forward * fireForce, ForceMode.Impulse);

            numFired += 1;

            if(uiText)
                uiText.text = "Num fired: " + numFired;
        }

        #endregion

        #region movement

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * speed;
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * speed;
        }
        if(Input.GetKey(KeyCode.Q))
        {
            transform.position -= transform.up * Time.deltaTime * speed;
        }
        if(Input.GetKey(KeyCode.E))
        {
            transform.position += transform.up * Time.deltaTime * speed;
        }        

        // Rotation with mouse
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed, Space.World);
        transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed, Space.Self);

        #endregion
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if(otherCollider.GetComponent<Rigidbody>())
        {
            collidingObject = otherCollider.gameObject;
        }
    }

    private void OnTriggerExit(Collider otherCollider)
    {
        if(otherCollider.GetComponent<Rigidbody>())
        {
            if(otherCollider.transform == collidingObject.transform)
            {
                collidingObject = null;
            }
        }
    }


    public void GrabObject(GameObject objectToGrab)
    {
        if(objectToGrab != null)
        {
            if(objectToGrab.GetComponent<Rigidbody>())
            {
                heldObject = objectToGrab;

                objectToGrab.transform.SetParent(transform);

                Rigidbody rb = heldObject.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                rb.useGravity = false;
            }
        }
    }

    private void ReleaseObject()
    {
        if (heldObject != null)
        {
            heldObject.transform.SetParent(null);

            Rigidbody rb = heldObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }

}
