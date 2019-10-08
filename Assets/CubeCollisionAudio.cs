using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollisionAudio : MonoBehaviour
{
    AudioSource source;

    private void OnCollisionEnter(Collision collision)
    {
        float speed = 0f;

        if(collision.gameObject.GetComponent<Rigidbody>())
        {
            speed = collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude;

            Debug.Log("speed of collision = " + speed);
        }

        if(speed > 1f) // 1 is our speed threshold
        {
            source.volume = Mathf.Clamp(speed * 0.22f, 0.1f, 1f); // I know max impact speed ~4.5m/s, and 0.22 * 4.5 gives me a value of 1 (max volume)

            source.pitch = Mathf.Clamp(speed / 3f, 0.5f, 1.5f); // Can change pitch based on speed of impact

            source.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
}
