using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lists : MonoBehaviour
{
    List<int> myIntList = new List<int>();

    List<Transform> myTransforms = new List<Transform>();
    
    public Transform otherTransform;

    // Start is called before the first frame update
    void Start()
    {
        myIntList.Add(1);
        myIntList.Add(14);
        myIntList.Add(107);

        int myInt = myIntList[0]; // This will make myInt = 1
        myInt = myIntList[2]; // This will make myInt = 107
        
        myTransforms.Add(transform);
        myTransforms.Add(otherTransform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
