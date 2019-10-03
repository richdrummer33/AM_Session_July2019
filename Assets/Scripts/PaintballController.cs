using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintballController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5f); // Countdown timer to destroy automatically in 5 seconds
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if(otherCollider.gameObject.GetComponent<Renderer>()) // Check that it's not an invisible collider!
        {
            otherCollider.gameObject.GetComponent<Renderer>().material = this.gameObject.GetComponent<Renderer>().material; // SPLAT - apply the paintball color to the object that was hit
        }

        Destroy(this.gameObject); // Destroy on  impact
    }

}
