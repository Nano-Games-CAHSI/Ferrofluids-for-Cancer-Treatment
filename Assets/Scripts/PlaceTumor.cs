using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/*
 General class to place 3D objects, in this case, a tumor asset.
 For future development, we might want to revisit this code so that 
 we can place different objects depending on the game progress/status.

 In addition, we also include the shoot behavior so the scrip is set
 to active once our tumor is placed in the AR enviroment.
 */

public class PlaceTumor : MonoBehaviour
{
    //Class attributes
    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;
    private GameObject spawnedObject;
    public GameObject shoot;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    //Begin session and find flat surfaces, make sure shooting behavior is off.
    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        shoot.SetActive(false);
    }

    //Checks if objects has already been placed. If it hasn't place new object by calling ARPlaceObject.
    //Otherwise, update object placement according to where the user clicked.
    //need to update placement indicator, placement pose and spawn 
    void Update()
    {
        if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject(); //at the moment this just spawns the gameobject
            shoot.SetActive(true);
        }

        UpdatePlacementPose();
        UpdatePlacementIndicator();


    }

    //Checks if object has been placed. If hasn't, set behavior active and update position.
    //If it has, set behavior off.
    void UpdatePlacementIndicator()
    {
        if (spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    //Keeps placement indicator at the center of the screen at all times, unless person taps a specific location.
    void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;
        }
    }

    //Spawns object.
    void ARPlaceObject()
    {
        spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
    }


}

