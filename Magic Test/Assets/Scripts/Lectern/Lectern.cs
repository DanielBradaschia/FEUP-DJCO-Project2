using UnityEngine;

public class Lectern : MonoBehaviour
{
    public GameObject text;
    public GameObject spellBookUI;

    Transform player;
    Transform lectern;
    
    void Start()
    {
        player = GameObject.Find("Player").transform;
        lectern = gameObject.transform;
    }
    
    void Update()
    {
        float dist = Vector3.Distance(player.position, lectern.position);
        if (dist <= 5)
        {
            text.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                spellBookUI.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                Time.timeScale = 0f;
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            text.SetActive(false);
            spellBookUI.SetActive(false);
        }
    }
    
}
