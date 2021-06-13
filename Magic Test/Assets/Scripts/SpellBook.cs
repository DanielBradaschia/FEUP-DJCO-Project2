using UnityEngine;
using UnityEngine.UI;

public class SpellBook : MonoBehaviour
{
    public GameObject selectedMagicsIcons;
    public GameObject allMagicsIcons;

    MagicManager manager;

    Magic[] selectedMagics;
    Magic[] allMagics;
    Image[] selectedChildren;
    Image[] allChildren;

    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<MagicManager>();
        selectedMagics = manager.getSelectedMagics();
        allMagics = manager.getAllMagics();

        selectedChildren = selectedMagicsIcons.GetComponentsInChildren<Image>();
        allChildren = allMagicsIcons.GetComponentsInChildren<Image>();
    }

    void Update()
    {
        for(int i = 0; i < selectedChildren.Length; i++)
        {
            selectedChildren[i].sprite = selectedMagics[i].getSprite();
        }
        for (int i = 0; i < allChildren.Length; i++)
        {
            allChildren[i].sprite = allMagics[i].getSprite();
            if(!allMagics[i].getLearned() || allMagics[i].getSelected())
            {
                Color c = allChildren[i].color;
                c.a = 0.20f;
                allChildren[i].color = c;

                allChildren[i].gameObject.GetComponent<UI_Drag>().enabled = false;
            }
            else
            {
                Color c = allChildren[i].color;
                c.a = 1f;
                allChildren[i].color = c;
                
                allChildren[i].gameObject.GetComponent<UI_Drag>().enabled = true;
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
