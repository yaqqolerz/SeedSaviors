using UnityEngine.SceneManagement;
using UnityEngine;

public class BacktoMainMenu : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void onClickToMenu()
    {
        SceneManager.LoadScene(sceneName);
    }
}
