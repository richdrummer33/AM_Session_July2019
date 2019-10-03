using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackpadMovement : MonoBehaviour
{
    public string trackpadAxisX, trackpadAxisY; // Axis names from Project Settings --> Inputs
    public float speed = 3f;
    public Transform xrRig; // Our feet, on the ground. A funky band once said "Get your feet back on the ground" - that's what we're gonna do

    public LayerMask raycastMask; // This will define what the raycast can hit
    
    // Update is called once per frame
    void Update()
    {
        float trackpadX = Input.GetAxis(trackpadAxisX); // A value between -1 and +1
        float trackpadY = Input.GetAxis(trackpadAxisY); // A value between -1 and +1

        Vector3 forward = transform.forward; // Want to set the "y" to zero, so need to assign  transform.forward new Vector3 that I can do that with
        forward.y = 0f; // Ensure that we do not move up or down (i.e. fly!)

        Vector3 right = transform.right;
        right.y = 0f; // Ensure that we do not move up or down (i.e. fly!)

        Vector3 direction = forward * trackpadY + right * trackpadX; // The direction and amount which we are moving fwd/back as well as left/right (but not up/down!)

        xrRig.position = xrRig.position + direction * Time.deltaTime * speed; // Now move!

        // Vertical movement - make sure the Xr Rig sticks to the terrain
        Vector3 rigPosition = xrRig.position; // Copy the xrRg's position to a Vector3 (which we can modify directly)
        rigPosition.y = GetFloorHeight(); // Modify the height value
        xrRig.transform.position = rigPosition; // XR Rig height now = ground hieght. A funky band once said "Get your feet back on the ground" - that's what we just did right here.
    }

    private float GetFloorHeight() // Function that calculates and returns the floor height as a float value
    {
        float floorHeight;

        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Vector3.down, out hit, Mathf.Infinity, raycastMask); // Raycasts down towards the ground to sense the hieght of the ground

        floorHeight = hit.point.y; // hit.point.y is the height of the ground

        return floorHeight; // Send this value to the caller!
    }
}
