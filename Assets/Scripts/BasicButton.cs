using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicButton : MonoBehaviour
{
    public Transform button;
    public Transform openPosition;
    public Transform closedPosition;

    public AudioSource source;

    private void OnTriggerEnter(Collider otherCollider) // Press the button
    {
        Debug.Log("Collided");
        button.position = closedPosition.position;
        source.Play();
    }

    private void OnTriggerExit(Collider otherCollider) // Release the button
    {
        button.position = openPosition.position;
    }
}
