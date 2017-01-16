using UnityEngine;

public class EnergyPulseBehaviour : MonoBehaviour
{
    public AudioClip shootSound;

    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    void Awake()
    {
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody targetRigidbody = other.GetComponent<Rigidbody>();
        if (targetRigidbody != null)
        {
            PlayerHealth player = targetRigidbody.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
