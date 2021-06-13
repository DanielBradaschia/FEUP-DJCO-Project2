using UnityEngine;
using UnityEngine.UI;

public class SpellBook : MonoBehaviour
{
    public MagicManager controller;

    Magic[] selectedMagics;
    Magic[] allMagics;

    void Start()
    {
        controller = GameObject.Find("Manager").GetComponent<MagicManager>();
        selectedMagics = controller.getSelectedMagics();
        foreach (Magic m in selectedMagics)
        {
            Debug.Log(m.gameObject);
        }
    }

    void Update()
    {
        
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
