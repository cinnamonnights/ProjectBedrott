using UnityEngine;
using UnityEngine.SceneManagement;

public class BedrottGameManager01 : MonoBehaviour
{
  public static BedrottGameManager01 Instance { get; private set; }
  [SerializeField]
  BedrottPlayer _bedrottController;
  [SerializeField]
  Canvas _gameOverCanvas, _pauseCanvas;
  
  [SerializeField]
  GameObject _exitDoor;
  
  int _remainingObjects;
  bool _isPaused = false;
  
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    _exitDoor.SetActive(false);
  }
  void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
    else
    {
      Destroy(gameObject);
    }
    _gameOverCanvas.gameObject.SetActive(false);
  }

  public void GameOver()
  {
    Time.timeScale = 0;
    Debug.Log("Game Over");
    _gameOverCanvas.gameObject.SetActive(true);
  }

  public void StartGame()
  {
    Time.timeScale = 1;
    Debug.Log("Game Restarted");
    _gameOverCanvas.gameObject.SetActive(false);
    _bedrottController.StartGame();
  }

  public void QuitGame()
  {
    //Note: This will not work in the editor, but will work in a built game
    Application.Quit();
    Debug.Log("Quit Game");
  }

  public void PauseGame()
  {
    if (_isPaused)
    {
      Time.timeScale = 1;
      _pauseCanvas.gameObject.SetActive(false);
      _isPaused = false;
    }
    else
    {
      Time.timeScale = 0;
      _pauseCanvas.gameObject.SetActive(true);
      _isPaused = true;
    }
  }
  public void ResetGame()
  {
    Time.timeScale = 1;
    SceneManager.LoadScene("Bedrotttesting");
  }

  public void RegisterObjective()
  {
    _remainingObjects++;
  }

  public void ObjectiveCollected()
  {
    _remainingObjects--;
    Debug.Log("Collected: " + _remainingObjects);
    if(_remainingObjects <= 0)
    {
      UnlockDoor();
    }
  }

  void UnlockDoor()
  {
    _exitDoor.SetActive(true);
    Debug.Log("Win Condition Unlocked");
  }
}
