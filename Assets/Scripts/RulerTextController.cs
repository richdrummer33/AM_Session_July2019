using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RulerTextController : MonoBehaviour
{
    public TextMeshPro rulerText;
    public LineRenderer line;
    
    void Update()
    {
        rulerText.transform.LookAt(Camera.current.transform.position); // Make text face the user (i.e. phone) at all times

        rulerText.text = System.Math.Round(Vector3.Distance(line.GetPosition(0), line.GetPosition(1)), 2) + " m"; // Set the text to the distance of the line!

        rulerText.transform.position = (line.GetPosition(0) + line.GetPosition(1)) / 2f; // Get Center point of the ruler-line
    }
}