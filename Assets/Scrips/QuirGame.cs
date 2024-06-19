using UnityEngine;

public class QuitGame : MonoBehaviour
{
    private void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitApplication();
        }
    }

    private void QuitApplication()
    {
        // Log the quit action for debugging purposes
        Debug.Log("Quitting the game.");
        
        // Quit the application
        Application.Quit();

        // If running in the editor, stop playing
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
