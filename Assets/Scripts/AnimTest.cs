using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTest : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > 3f)
        {
            anim.SetBool("Transition1", true);
        }
        if(Time.time > 9f)
        {
            anim.SetFloat("T2", 1.2f);
        }     
    }
}
