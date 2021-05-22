using UnityEngine;

public class FallArea : MonoBehaviour
{
    public Vector3 position;
    public Vector3 rotation;

    private void OnTriggerEnter(Collider other)
    {
        GameObject player = other.gameObject;
        if (player.tag == "Player")
        {
            player.transform.position = position;
            player.transform.rotation = Quaternion.Euler(rotation);

            CharacterBehaviour cb = player.GetComponent<CharacterBehaviour>();
            cb.TakeDamage(30f);
        }
    }

    
}
