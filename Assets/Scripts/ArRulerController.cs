using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// Script will instantiate ruler on-touchscreen press and move the ruler while press is held. On press release, ruler will stop.
/// </summary>
public class ArRulerController : MonoBehaviour
{
    public ARRaycastManager raycastManager; // Allows for raycast in XR

    public LineRenderer rulerPrefab;

    private LineRenderer currentRuler; // A reference to the instance of the ruler
    
    void Update()
    {
        Vector2 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f)); // Get the position at the center of the AR Camera (essentially your phone display)

        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        raycastManager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon); 

        if(Input.touchCount > 0) // At least 1 fuinger touching screen, then make a ruler
        { 
            if(hits.Count > 0) // CAn render a ruler line on surface (PlaneWithinPolygon)
            {
                if (currentRuler == null) // We don't have a ruler yet, let's make one
                {
                    currentRuler = Instantiate(rulerPrefab, hits[0].pose.position, rulerPrefab.transform.rotation);
                    currentRuler.SetPosition(0, hits[0].pose.position); // Set start of the ruler
                } 

                currentRuler.SetPosition(1, hits[0].pose.position); // Set end of the ruler
            }
        }
        else // We've released our finger from the screen
        {
            currentRuler = null; 
        }
    }
}
