using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonTest : MonoBehaviour
{
    public Text text;    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMyClick()
    {
        text.text = "You clicked me :(";
        SceneManager.LoadScene("AM_session_3", LoadSceneMode.Single);
    }
}
