using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<Button> MyButtons = new List<Button>();

    public bool answeredCorrectly; // NEW -- Tracks if user selected the correct answer 

    public int correctAnswer; // NEW -- Defines which buttin (in MyButtins) is the correct answer

    public void Answer(Button theButtonThatWasPressed)
    {
        if(MyButtons.IndexOf(theButtonThatWasPressed) == correctAnswer)
        {
            answeredCorrectly = true;
            Debug.Log("theButtonThatWasPressed " + theButtonThatWasPressed.name);
        }
    }
}