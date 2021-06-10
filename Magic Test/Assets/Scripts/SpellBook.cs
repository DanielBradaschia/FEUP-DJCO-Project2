using UnityEngine;
using UnityEngine.UI;

public class SpellBook : MonoBehaviour
{
    public MagicController controller;

    Magic[] selectedMagics;
    Magic[] allMagics;

    void Start()
    {
        selectedMagics = controller.GetMagics();
        /*foreach (Magic currentSprite in selectedMagics)
        {
            GameObject NewObj = new GameObject(); //Create the GameObject
            Image NewImage = NewObj.AddComponent<Image>(); //Add the Image Component script
            NewImage.sprite = currentSprite; //Set the Sprite of the Image Component on the new GameObject
            NewObj.GetComponent<RectTransform>().SetParent(ParentPanel.transform); //Assign the newly created Image GameObject as a Child of the Parent Panel.
            NewObj.SetActive(true); //Activate the GameObject
        }*/
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
