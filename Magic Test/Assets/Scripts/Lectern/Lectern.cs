using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Lectern : MonoBehaviour
{
    public GameObject text;
    public GameObject spellBookUI;

    Transform player;
    Transform lectern;
    bool isChoosing;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        lectern = gameObject.transform;
        isChoosing = false;
    }
    
    void Update()
    {
        float dist = Vector3.Distance(player.position, lectern.position);
        if (dist <= 5)
        {
            text.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (isChoosing)
                    returnGame();
                else
                    chooseSpells();
            }
        }
        else
        {
            returnGame();
        }
    }

    void chooseSpells() 
    {
        spellBookUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
        isChoosing = true;
    }

    void returnGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        text.SetActive(false);
        spellBookUI.SetActive(false);
        isChoosing = false;
    }
    
}
