using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocateTumor : MonoBehaviour
{
    // Variables for touch input and touch position
    private InputAction touch;
    private InputAction touchPosition;
    private PlayerInput input;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
        touch = input.actions["TouchTumor"];
        touchPosition = input.actions["TouchPos"];
    }
    // Checks if the user has touched the tumor
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPosition.ReadValue<Vector2>());
        RaycastHit hit;

        if (touch.WasPerformedThisFrame() && Physics.Raycast(ray, out hit) && hit.collider.tag == "Tumor")
        {
            Debug.Log("Touched"); // Only for debugging
        }
    }
}
