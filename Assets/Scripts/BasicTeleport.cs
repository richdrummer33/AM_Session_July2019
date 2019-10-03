using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTeleport : MonoBehaviour
{
    public Transform xrRig;

    private LineRenderer line;

    public GameObject markerGraphicPrafab;
    private GameObject currentMarkerGraphic;

    private RaycastHit hit = new RaycastHit();

    //a
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.enabled = false;
    }

    void Update()
    {
        if (Input.GetButton("Left Trackpad Push"))
        {
            line.enabled = true;

            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            { // We are pointing at a collider

                line.SetPosition(0, transform.position);

                line.SetPosition(1, hit.point);

                if (currentMarkerGraphic != null)
                {
                    currentMarkerGraphic.transform.position = hit.point + new Vector3(0f, 0.1f, 0f);
                }
                else
                {
                    currentMarkerGraphic = Instantiate(markerGraphicPrafab, hit.point + new Vector3(0f, 0.1f, 0f), markerGraphicPrafab.transform.rotation);
                }
            }
            else // We are pointing off into empty space
            {
                line.SetPosition(0, transform.position);
                line.SetPosition(1, transform.position + transform.forward * 100f);
                hit = default;

                Destroy(currentMarkerGraphic);
            }
        }
        else // Not holding button - Check to teleport
        {
            if (hit.transform)
            {
                if (hit.transform.tag == "Ground")
                {
                    Vector3 offsetFix = xrRig.position - Camera.main.transform.position;
                    xrRig.position = hit.point + new Vector3(offsetFix.x, 0f, offsetFix.z); // Teleport
                }
            }

            line.enabled = false;
            Destroy(currentMarkerGraphic);
            hit = default;
        }
    }
}
