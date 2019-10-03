using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMover : MonoBehaviour
{
    public SlidingLeverController forwardsLever;

    public SlidingLeverController sidewaysLever;

    public float moveSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        float forwardMovement = forwardsLever.GetNormalizedPosition();
        transform.position += transform.forward * forwardMovement * Time.deltaTime * moveSpeed;

        float sidewaysMovement = sidewaysLever.GetNormalizedPosition();
        transform.position += transform.right * sidewaysMovement * Time.deltaTime * moveSpeed;
    }
}
