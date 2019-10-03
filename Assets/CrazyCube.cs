using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyCube : MonoBehaviour
{
    Vector3 direction;

    float seedx;
    float seedy;
    float seedz;

    // Start is called before the first frame update
    void Start()
    {
        seedx = Random.Range(2f, 4f);
        seedy = Random.Range(2f, 4f);
        seedz = Random.Range(2f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Mathf.Sin(seedx * Time.time) * Time.deltaTime;
        direction.y = Mathf.Sin(seedy * Time.time) * Time.deltaTime;
        direction.z = Mathf.Sin(seedz * Time.time) * Time.deltaTime;

        transform.position += direction;
    }
}
