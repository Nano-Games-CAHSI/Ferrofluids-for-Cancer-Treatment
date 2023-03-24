using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Class function is to change phases */
public class PhaseSwitcher : MonoBehaviour
{
    public GameObject button;

    // Moves to next phase or scene (When the other phases are implemented further testing will be necesary)
    public void nextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Shows button on screen
    public void activateButton(){
        button.SetActive(true);
    }

   
}
