using UnityEngine;
using System.Collections;
using System;

public class StickBehaviourScript : Weapon
{

    public AudioClip selectSound;
    public AudioClip hitSound;
    public GameObject ammunition;
    public AudioClip shootSound;

    private float enabledTimeInSec = 2.0f;
    private float startTime = 0.0f;

    void Start()
    {
        weaponType = AvailableWeapons.Stick;
        this.gameObject. = false;
    }

    void Awake()
    {
    }

    void Update()
    {
        if (Time.realtimeSinceStartup >= this.startTime + this.enabledTimeInSec)
        {
            this.enabled = false;
        }
    }

    void OnDestroy()
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
                if (hitSound)
                {
                    AudioSource.PlayClipAtPoint(hitSound, transform.position, 10.0f);
                }
            }
        }
    }

    public override void fire()
    {
        if (shootSound)
        {
            AudioSource.PlayClipAtPoint(shootSound, transform.position);
        }
        this.enabled = true;
        this.startTime = Time.realtimeSinceStartup;
    }

    public override void stop()
    {

    }

    public override void select()
    {
    }
}
