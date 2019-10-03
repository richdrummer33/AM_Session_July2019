using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonJointLever : InteractableLever
{
    public Transform upperLimit; // Defines the range/limits of motion of the handle
    public Transform lowerLimit;

    Vector3 heading; // This is the direction of handle-motion
    Vector3 centerPosition;
    float magnitudeOfHeading; // Total length of motion (range/limits)

    Transform playerHand; // Keep record when we are grabbing

    public bool allowPositionReset = true;

    Vector3 aimPosition;

    public Transform pivotPoint;

    public Transform leverBase;

    // Start is called before the first frame update
    void Start()
    {
        heading = upperLimit.position - lowerLimit.position;

        magnitudeOfHeading = heading.magnitude;

        centerPosition = transform.position; // Handle is centered in this prefab on Start

        aimPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHand != null)
        {
            Vector3 startToHand = playerHand.position - lowerLimit.position; // Vector from the start pos to the hand

            Vector3 normalizedHeading = heading.normalized; // Make it length = 1

            float dotProduct = Vector3.Dot(startToHand, normalizedHeading); // get the distance to move the handle from the lower limit position

            float clampedDotProduct = Mathf.Clamp(dotProduct, 0f, magnitudeOfHeading); // PRevent handle from exceeding bounds

            aimPosition = lowerLimit.position + normalizedHeading * clampedDotProduct;
        }
        else if (allowPositionReset) // Optional feature to make the lever rotate back to the vertical orientation when let go of it
        {
            aimPosition += (centerPosition - aimPosition) * Time.deltaTime * 3f;
        }

        pivotPoint.LookAt(aimPosition);
    }

    public override float GetNormalizedPosition() // Return a float value which is the handle's normalized position between -1 and +1 (removes dependency on the scal/size of lever)
    {
        float signedAngle = Vector3.SignedAngle(leverBase.up, pivotPoint.forward, leverBase.forward); // In degrees (+/-)

        return signedAngle / 45f;
    }

    #region Grab and Release

    public override void GrabAction(Transform hand) // This func will be called by our sim hand and/or XR hand
    {
        playerHand = hand;

        base.GrabAction(hand);
    }

    public override void ReleaseAction()
    {
        playerHand = null;

        base.ReleaseAction();
    }

    #endregion
}
