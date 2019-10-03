using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetArCanvasInstructions : MonoBehaviour
{
    public List<GameObject> steps = new List<GameObject>();

    public ArCanvasInstructionsController arController;

    public void StartInstructionRoutine()
    {
        arController.StartInstructions(steps);
    }
}