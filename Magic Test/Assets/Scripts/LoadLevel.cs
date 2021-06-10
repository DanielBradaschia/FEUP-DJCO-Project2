using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public string level;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
            SceneManager.LoadScene(level);
    }
}
