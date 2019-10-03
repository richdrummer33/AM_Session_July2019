using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Accessible from anywhere in your project
    public static GameManager instance; // Singleton - static means that "instance" belong to the GameManager class itself

    int numObjectsDestroyed;
    int numObjectsToDestroy; // How many objects we need to destroy to win

    public List<GameObject> objectsToDestroy = new List<GameObject>();

    public TextMeshPro textMesh;

    public float timeRemaining = 30f;

    void Start()
    {
        instance = this;

        numObjectsToDestroy = objectsToDestroy.Count;
    }

    void Update()
    {
        timeRemaining = timeRemaining - Time.deltaTime; // Countdown timer

        if (timeRemaining > 0f) // Still ahve time left
        {
            if (numObjectsToDestroy > 0) // We haven't won yet
            {
                textMesh.text = "Cubes Destroyed: " + numObjectsDestroyed  
                    + "\nCubes Remaining: " + numObjectsToDestroy 
                    + "\nTime Remaining: " + System.Math.Round(timeRemaining, 2);
            }
            else
            {
                textMesh.text = "YOU WIN!!";
            }
        }
        else // Ran out of time
        {
            textMesh.text = "GAME OVER MAN!!!";
        }
    }

    public void ObjectDestroyed(GameObject objectThatWasDestroyed)
    {
        if (objectsToDestroy.Contains(objectThatWasDestroyed))
        {
            numObjectsDestroyed = numObjectsDestroyed + 1;
            numObjectsToDestroy = numObjectsToDestroy - 1;
        }
    }
}
