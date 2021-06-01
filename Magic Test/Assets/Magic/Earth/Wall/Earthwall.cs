using UnityEngine;

public class Earthwall : MonoBehaviour
{
    public float duration = 3;
    float timer;

    void Start()
    {
        transform.localScale = new Vector3(1, 0.01f, 1);
        timer = duration;
    }


    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }

        if (transform.localScale.y < 1)
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0f);
        }
    }
}
