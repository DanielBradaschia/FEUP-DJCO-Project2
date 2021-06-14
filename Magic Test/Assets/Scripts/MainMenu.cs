using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }
    public void LoadGame ()
    {

    }
    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
