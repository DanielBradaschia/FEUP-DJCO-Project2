using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public int level;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
            SceneManager.LoadScene(level);
    }
}
