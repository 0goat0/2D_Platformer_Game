using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;
    public GameObject gameOverUI;


    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (HealthManager.heart <= 0)
            {
                return;
            } 

            if (Time.timeScale == 0f)
            {
                Pause();
            }
            else
            {
                GameOver();
            }
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartScenes");
        Time.timeScale = 1;
    }
    public void StartClick()=> SceneManager.LoadScene("Stage1");
    public void ExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#endif
        Application.Quit();
    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void Pause()
    {
        if (HealthManager.heart >= 0)
        {
            gameOverUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    //public void GameClear()
    //{
    //    gameClearUI.SetActive(true);
    //}


}
