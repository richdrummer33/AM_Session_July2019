using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CLASS REF: [[[WRECKING BALL]]]
public class MoveBox : MonoBehaviour
{
    public InteractableLever leverSidewaysMovement;
    public InteractableLever leverForwardsMovement;

    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * leverForwardsMovement.GetNormalizedPosition() * Time.deltaTime * moveSpeed;
        transform.position += transform.right * leverSidewaysMovement.GetNormalizedPosition() * Time.deltaTime * moveSpeed;
    }
}
