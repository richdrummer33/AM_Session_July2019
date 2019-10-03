using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArCanvasInstructionsController : MonoBehaviour
{
    public GameObject taskSelectionCanvas;
    public GameObject instructionsCanvas;

    public GameObject progressButtonCanvas; // 2D Screen-overlay canvas with a button to moe to next step

    private List<GameObject> steps = new List<GameObject>();

    private int currentStep = 0;

    public void StartInstructions(List<GameObject> mySteps)
    {
        steps = mySteps; // Assigning the list of steps to step through

        instructionsCanvas.SetActive(true);
        progressButtonCanvas.SetActive(true); // My 2D button

        taskSelectionCanvas.SetActive(false);

        steps[0].SetActive(true);
    }

    public void NextStep()
    {
        if(instructionsCanvas.activeSelf == true) // Checking to see that we are in an instructions sequence/routine
        {
            steps[currentStep].SetActive(false); // Disable the current step

            currentStep++; // This increments this variable by 1

            if(currentStep < steps.Count) // Move to next step now!
            {
                steps[currentStep].SetActive(true);
            }
            else // We are done the instructions sequence
            {
                StartSelection();
            }
        }
    }

    private void StartSelection() // Restarting the session - now user can select another task
    {
        taskSelectionCanvas.SetActive(true);
        instructionsCanvas.SetActive(false);
        progressButtonCanvas.SetActive(false);

        currentStep = 0;
    }
}
