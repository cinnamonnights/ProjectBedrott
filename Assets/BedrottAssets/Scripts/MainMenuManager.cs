using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
  public void LoadScene(string sceneName)
  {
    Debug.Log(sceneName);
    SceneManager.LoadScene(sceneName);
  }
  public void ExitGame()
  {
    Application.Quit();
    Debug.Log("Quit Game");
  }
}
