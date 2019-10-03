using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrLocomotion : MonoBehaviour
{
    public string trackpadAxisX, trackpadAxisY;
    public float speed = 3f;
    public Transform xrRig;

    public LayerMask mask;

    public bool debug = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float trackpadX = Input.GetAxis(trackpadAxisX); // Is a number between -1 and 1
        float trackpadY = Input.GetAxis(trackpadAxisY); // Is a number between -1 and 1

        Vector3 forward = transform.forward;
        forward.y = 0f;

        Vector3 right = transform.right;
        right.y = 0f;

        // Lateral movement (x/z plane)
        xrRig.Translate((forward * trackpadY + right * trackpadX) * speed * Time.deltaTime);

        // Vertical Movement
        Vector3 rigPosition = xrRig.position;
        rigPosition.y = GetFloorHeight();
        xrRig.transform.position = rigPosition;        
    }

    private float GetFloorHeight()
    {
        RaycastHit hit;

        Physics.Raycast(Camera.main.transform.position, Vector3.down, out hit, Mathf.Infinity, mask);

        float floorHeight = hit.point.y;

        return floorHeight;
    }
}
