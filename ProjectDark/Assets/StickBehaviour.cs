using UnityEngine;

public class StickBehaviour : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody targetRigidbody = other.GetComponent<Rigidbody>();
        PlayerHealth player = targetRigidbody.GetComponent<PlayerHealth>();
        player.TakeDamage();
    }

}
