using UnityEngine;

public class LaserGunBehaviour : Weapon
{

    public AudioClip selectSound;
    public AudioClip hitSound;
    public GameObject ammunition;

    private float hitsPerSecond = 1.0f;
    private float timeSinceLastDamage = 0.0f;

    void Start()
    {
        weaponType = AvailableWeapons.LaserGun;
        continuesFiring = true;
    }

    void Awake()
    {
    }

    public override void fire()
    {
        RaycastHit rayCastHit;
        if (Physics.Raycast(transform.position, transform.forward, out rayCastHit))
        {
            //Quaternion.FromToRotation(Vector3.up, rayCast.normal);
            PlayerHealth player = rayCastHit.collider.GetComponent<PlayerHealth>();
            if (player != null)
            {
                if (Time.realtimeSinceStartup - timeSinceLastDamage >= 1.0f / hitsPerSecond)
                {
                    timeSinceLastDamage = Time.realtimeSinceStartup;
                    player.TakeDamage();
                    // Remark: this is a really bad position for the sound if we want to have a 
                    // hit sound depending on the TARGET material. For now the hit sound is depending on the weapon.
                    //AudioSource.PlayClipAtPoint(hitSound, transform.position, 10.0f);
                }
            }
        }
    }

    public override void select()
    {

    }
}
