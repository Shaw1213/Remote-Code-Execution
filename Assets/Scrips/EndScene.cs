using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    // Method to switch to a specific scene
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Optional: Method to switch to the next scene in the build index
    public void SwitchToNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("End");
        SwitchToNextScene();
    }
}   
