using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyCube : MonoBehaviour
{
    Vector3 direction;

    public float freq = 3f;
    public float amplitude = 2f;

    float seedx;
    float seedy;
    float seedz;

    // Start is called before the first frame update
    void Start()
    {
        seedx = Random.Range(freq, freq * 2f);
        seedy = Random.Range(freq, freq * 2f);
        seedz = Random.Range(freq, freq * 2f);
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Mathf.Sin(seedx * Time.time) * Time.deltaTime * amplitude;
        direction.y = Mathf.Sin(seedy * Time.time) * Time.deltaTime * amplitude;
        direction.z = Mathf.Sin(seedz * Time.time) * Time.deltaTime * amplitude;

        transform.position += direction;
    }
}
