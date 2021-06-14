using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject Player;

    public AudioSource pauseON;
    public AudioSource pauseOFF;
    public AudioSource ambient;

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
        pauseOFF.Play();
        ambient.mute = false;
        Player.GetComponent<PlayerMovement>().enabled = true;
        Player.GetComponent<MagicController>().enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Pause ()
    {
        pauseON.Play();
        ambient.mute = true;
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponent<MagicController>().enabled = false;
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
