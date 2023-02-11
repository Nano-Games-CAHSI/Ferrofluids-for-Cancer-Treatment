using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 This class defines the behavior of ferrofluids 'exploding' when coming into contact with he tumor.
 It is an indicator that the user is aiming where they should.
 */
public class Explode : MonoBehaviour
{
    //Class attribute
    public GameObject explosion;

    //Checks if collision is triggered with an object with the tag 'Tumor'.
    //If so, activate particle effects on the collision site.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Tumor")
        {
            Instantiate(explosion, collision.transform.position, collision.transform.rotation);
        }
    }
}
