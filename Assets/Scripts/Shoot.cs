using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 This class defines the behavior of shooting ferrofluids towards the tumor once it has been placed.
 */
public class Shoot : MonoBehaviour
{
    //Class attributes
    public Transform arCamera;
    public GameObject projectile;
    public float shootForce = 700.0f;

    //Update function will begin the shooting once you begin pressing on your screen after the tumor has already been set.
    void Update()
    {
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            GameObject bullet = Instantiate(projectile, arCamera.position, arCamera.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(arCamera.forward * shootForce);
        }
    }
}


