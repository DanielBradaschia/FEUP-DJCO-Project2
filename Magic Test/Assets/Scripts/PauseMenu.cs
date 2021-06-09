using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject Player;

    private void Start()
    {
        Player.GetComponent<PlayerMovement>().enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

   public void Resume ()
    {
      Player.GetComponent<PlayerMovement>().enabled = true;
      pauseMenuUI.SetActive(false);
      Time.timeScale = 1f;
      GameIsPaused = false;
      Cursor.visible = false;
      
      Cursor.lockState = CursorLockMode.Locked;
    }
    void Pause ()
    {
       Player.GetComponent<PlayerMovement>().enabled = false;
       pauseMenuUI.SetActive(true);
       Time.timeScale = 0f;
       GameIsPaused = true;
       Cursor.visible = true;
       Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMenu()
        {
           Debug.Log("Loading menu...");
        }

    public void QuitGame()
    {
        SceneManager.LoadScene("Title_Screen");
    }
}
