using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void OnstartClick()
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
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            GameQuit();
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
