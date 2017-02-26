using UnityEngine;

public class EnergyPulseBehaviour : Weapon
{
    public AudioClip shootSound;
    public AudioClip hitSound;

    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    void Awake()
    {
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
                // Remark: this is a really bad position for the sound if we want to have a 
                // hit sound depending on the TARGET material. For now the hit sound is depending on the weapon.
                AudioSource.PlayClipAtPoint(hitSound, transform.position, 10.0f);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public override void fire()
    {
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
    }
}
