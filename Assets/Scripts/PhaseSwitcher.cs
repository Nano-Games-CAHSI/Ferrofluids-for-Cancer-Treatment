using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Class function is to change phases */
public class PhaseSwitcher : MonoBehaviour
{
    public GameObject button;
    public void nextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Shows button on screen
    public void activateButton(){
        button.SetActive(true);
    }

   
}
