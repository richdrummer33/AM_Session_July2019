using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        // Tell the Game Manager that a cube has been destroyed
        GameManager.instance.ObjectDestroyed(col.gameObject);

        Destroy(col.gameObject);

        GetComponent<AudioSource>().Play();
    }
}
