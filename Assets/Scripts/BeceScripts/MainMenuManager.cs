using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject racingUI;
    void Start()
    {
        Time.timeScale = 0;
    }
    public void StartGame()
    {
        gameObject.SetActive(false);
        racingUI.SetActive(true);
        Time.timeScale = 1;

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
