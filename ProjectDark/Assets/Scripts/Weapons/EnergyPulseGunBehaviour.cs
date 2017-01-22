using UnityEngine;

public class EnergyPulseGunBehaviour : Weapon
{
    public AudioClip selectSound;
    public AudioClip hitSound;
    public GameObject ammunition;

    void Start()
    {
        weaponType = AvailableWeapons.EnergyPulseGun;
    }

    void Awake()
    {
    }

    public override void fire()
    {
        Transform transform = GetComponent<Transform>();
        GameObject bullet = Instantiate(ammunition, transform.position, transform.rotation) as GameObject;
        bullet.GetComponent<Weapon>().fire();
    }

    public override void select()
    {

    }
}
