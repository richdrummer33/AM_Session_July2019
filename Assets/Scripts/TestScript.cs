using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public int i;
    public float testFloat;
    public string myPhrase;

    public BoxCollider myBoxCollider;

    public Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myPhrase = "Richard is da boss";
        myBoxCollider.isTrigger = false;
        myTransform.position = new Vector3(0f, 5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        i = i + 1;
    }
}