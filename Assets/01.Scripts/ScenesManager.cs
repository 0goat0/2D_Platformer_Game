using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#endif
        Application.Quit();
    }
    //public void OnPause()
    //{
    //    if(Keyboard.current.escapeKey.isPressed)
    //    {
    //        Time.timeScale = 0;
    //    }
        
    //}



    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.Escape))
    //        GameQuit();
    //}
    //public void GameQuit()
    //{
    //    Application.Quit();
    //}
}
