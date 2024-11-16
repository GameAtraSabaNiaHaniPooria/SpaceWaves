using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  
    private bool isGamePaused = false;

    void Start()
    {
        
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
       
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void UnpauseGame()
    {
        
        Time.timeScale = 1f;
        isGamePaused = false;
    }
}
