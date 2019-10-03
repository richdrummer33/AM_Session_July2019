using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintballGun : InteractableObject
{
    public Transform muzzle; // This is reference to ther muzzle transform

    public GameObject paintballPrefab; // This will be the paintball itself, which we will instantiate and "fire"

    public float fireForce = 100f; // To apply velocity to paintball on instantiation

    public override void InteractStart() // Instantiate ball and add force - This function will be called by our grab script (when pushing trigger)
    {
        GameObject paintballInstance = Instantiate(paintballPrefab, muzzle.position, paintballPrefab.transform.rotation); // Create a copy of the prefab into the scene!

        paintballInstance.GetComponent<Rigidbody>().AddForce(muzzle.forward * fireForce, ForceMode.Impulse); // Add instantaneous force to make the paintball fly in the z-direction of the muzzle transform

        base.InteractStart(); // Optional 
    }
}
