using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadPhase0()
    {
        SceneManager.LoadScene("ARSetUp");
    }

    public void LoadPhase1()
    {
        SceneManager.LoadScene("AR_FerrofluidGame_Phase1");
    }
}
