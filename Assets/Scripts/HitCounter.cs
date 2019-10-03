using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitCounter : MonoBehaviour
{
    public Text uiText;
    private int i;

    private void OnCollisionEnter(Collision col)
    {
        i++;
        uiText.text = "Number of hits: " + i;
    }
}
