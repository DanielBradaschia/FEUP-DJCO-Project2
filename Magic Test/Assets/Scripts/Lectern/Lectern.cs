using UnityEngine;

public class Lectern : MonoBehaviour
{
    public GameObject text;
    public GameObject spellBookUI;

    GameObject player;
    Transform lectern;
    
    void Start()
    {
        player = GameObject.Find("Player");
        lectern = gameObject.transform;
    }
    
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, lectern.position);
       
        if (dist <= 5f)
        {
            text.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                player.GetComponent<PlayerMovement>().enabled = false;
                spellBookUI.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                Time.timeScale = 0f;
            }
        }
        else
        {
            text.SetActive(false);
        }
    }
    
}
