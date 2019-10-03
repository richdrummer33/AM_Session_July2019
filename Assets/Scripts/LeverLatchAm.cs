using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverLatchAm : MonoBehaviour
{
    private void OnTriggerStay(Collider otherCollider)
    {
        if(otherCollider.transform.parent == this.transform.parent) // If the other collider is part of this lever prefab
        {
            GetComponent<Rigidbody>().AddForce(otherCollider.transform.right * 20f);
        }
    }
}
