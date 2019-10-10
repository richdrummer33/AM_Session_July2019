using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefab; // Mirror
    GameObject instance;

    ARRaycastManager raycastManager;
    
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }
    
    void Update()
    {
        if(Input.touchCount > 0) // Touching the screen
        {
            Vector2 screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0f)); // Convert the position at 50% on the X and 50% Y of our phone's screen to an actual Vector2 coordinate that Unity understands

            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            if (raycastManager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
            {
                Vector3 hitPos = hits[0].pose.position;

                if(instance == null) // If not yet instantiated, do so!
                {
                    instance = Instantiate(prefab, hitPos, prefab.transform.rotation);
                }

                instance.transform.position = hitPos; // Continue to update position of the prefab while touching the screen

                LookAtPlayer();
            }
        }
    }

    /// <summary>
    /// Rotate the prefab about the world-space y-axis (i.e. pivot the mirror around the vertical axis)
    /// </summary>
    public void LookAtPlayer()
    {
        Vector3 lookDirection = Camera.main.transform.position - instance.transform.position; // Direction in which to look

        Quaternion lookRotation = Quaternion.LookRotation(lookDirection); // Convert direction into a rotation

        Vector3 eulerRotationAngles = new Vector3(instance.transform.eulerAngles.x, lookRotation.eulerAngles.y, instance.transform.eulerAngles.z); // Maintain the angles around x and z axis, but apply new rotation around the vertical y-axis

        instance.transform.rotation = Quaternion.Euler(eulerRotationAngles); // Apply the rotation to the instance! This line of code actually makes the thing rotate
    }
}
