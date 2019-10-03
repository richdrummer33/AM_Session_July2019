using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLever : InteractableObject
{
    public virtual float GetNormalizedPosition()
    {
        return 0f; // Arbitrary default value 
    }
}
