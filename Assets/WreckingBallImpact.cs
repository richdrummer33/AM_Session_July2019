using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallImpact : MonoBehaviour
{
    ParticleSystem explodeParticle;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody>())
        {
            explodeParticle.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        explodeParticle = GetComponentInChildren<ParticleSystem>();
    }

}
