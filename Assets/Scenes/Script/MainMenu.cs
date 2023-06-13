using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    public void Team()
    {
        SceneManager.LoadScene("Team");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoBackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
