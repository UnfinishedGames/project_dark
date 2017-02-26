using UnityEngine;
using UnityEngine.Networking;

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
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 2;
        NetworkServer.Spawn(bullet);
        bullet.GetComponent<Weapon>().fire();
    }

    public override void select()
    {

    }
}
