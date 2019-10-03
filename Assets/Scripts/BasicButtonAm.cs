using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicButtonAm : MonoBehaviour
{
    public Transform closedPosition;

    private Vector3 openPosition;

    public Transform button;

    public List<Rigidbody> myRigidbodies = new List<Rigidbody>();

    //private Rigidbody[] myRigidbodies;

    public float force = 20f;

    private void OnTriggerEnter(Collider otherCollider)
    {
        Debug.Log("Collided");
        button.position = closedPosition.position;

        GetComponent<AudioSource>().Play();

        /*foreach(Rigidbody rigidbody in myRigidbodies)
        {
            rigidbody.AddForce(-Vector3.right * 20f, ForceMode.Impulse);
        }*/

        // i is the index of the array or list 
        // i < length is the condition that determines if the loop should keep looping 
        // i++ just increments the index every loop iteration
        for (int i = 0; i < myRigidbodies.Count; i++) 
        {
            myRigidbodies[i].GetComponent<Rigidbody>().AddForce(-Vector3.right * 20f, ForceMode.Impulse);
        }
    }

    private void OnTriggerExit(Collider otherCollider)
    {
        Debug.Log("Done");
        button.position = openPosition;
    }

    void Start()
    {
        Debug.Log("Assigned pos");
        openPosition = button.transform.position; // Save original "open" position
    }
}
