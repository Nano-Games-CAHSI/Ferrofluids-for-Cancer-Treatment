using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; 

public class LocateTumor : MonoBehaviour
{
    // Reference to the PlayerInput component
    public PlayerInput input;

    // Reference to the DebugText UI element
    public TextMeshProUGUI DebugText;

    // Reference to the CountUpTimer script
    public CountUpTimer countUpTimer;

    // Input action for detecting touch on the tumor
    private InputAction touch;

    // Input action for tracking touch position
    private InputAction touchPosition;

    // Reference to main camera in the scene
    private Camera mainCamera;

    // Awake is called when the script instance is being loaded,
    void Awake()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found. Make sure it's tagged as 'MainCamera'");
        }
    }

    void Start()
    {
        touch = input.actions.FindAction("TouchTumor");
        touchPosition = input.actions.FindAction("TouchPos");
    }

    // Checks if the user has touched the tumor
    void Update()
    {
        // Exit early if the main camera is not found
        if (mainCamera == null) return;

        // Check if the "TouchTumor" input action was performed this frame
        if (touch.WasPerformedThisFrame())
        {
            Ray ray = mainCamera.ScreenPointToRay(touchPosition.ReadValue<Vector2>());
            RaycastHit hit;

            // If the ray hits an object with the "Tumor" tag, perform the desired actions
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Tumor"))
            {
                if (DebugText != null) DebugText.text = "Touched";

                // Save elapsed time value in PlayerPrefs
                PlayerPrefs.SetFloat("ElapsedTime", countUpTimer.GetElapsedTime());
                SceneManager.LoadScene("EndGame");
            }
        }
    }
}
