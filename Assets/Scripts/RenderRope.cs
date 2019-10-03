using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CLASS REF
[ExecuteInEditMode]
public class RenderRope : MonoBehaviour
{
    LineRenderer line;
    public Transform start;
    public Transform end;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        line.SetPosition(0, start.transform.position);
        line.SetPosition(1, end.position);
    }
}
