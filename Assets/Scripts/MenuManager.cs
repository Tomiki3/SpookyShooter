using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void StartTuto()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
