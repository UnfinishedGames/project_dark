using UnityEngine;

public class FlashlightBehaviour : Weapon
{

    public AudioClip selectSound;
    public AudioClip hitSound;

    void Start()
    {
        weaponType = AvailableWeapons.Flashlight;
    }

    void Awake()
    {
        //AudioSource.PlayClipAtPoint(selectSound, transform.position);
    }

    public override void fire()
    {
        // Do nothing - its just a light
    }

    public override void select()
    {

    }
}
