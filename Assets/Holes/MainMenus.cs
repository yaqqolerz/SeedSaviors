using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenus : MonoBehaviour
{
    public void Team()
    {
        SceneManager.LoadScene("Team");
    }
    public void MainGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void DemoLevel()
    {
        SceneManager.LoadScene("Demo Level");

    }

    public void OpenLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
