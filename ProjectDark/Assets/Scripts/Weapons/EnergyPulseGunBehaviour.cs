using UnityEngine;

public class EnergyPulseGunBehaviour : Weapon
{
    public AudioClip selectSound;
    public AudioClip hitSound;
    public GameObject ammunition;
    public GameObject bullet;

    void Start()
    {
        weaponType = AvailableWeapons.EnergyPulse;
    }

    void Awake()
    {
    }

    public override void fire()
    {
        Transform transform = GetComponent<Transform>();
        bullet = Instantiate(ammunition, transform.position, transform.rotation) as GameObject;
        bullet.GetComponent<Weapon>().fire();
    }

    public override void select()
    {

    }
}
