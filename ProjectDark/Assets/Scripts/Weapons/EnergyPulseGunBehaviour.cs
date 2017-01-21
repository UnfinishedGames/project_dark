using UnityEngine;

public class EnergyPulseGunBehaviour : Weapon
{
    public AudioClip selectSound;
    public AudioClip hitSound;
    public GameObject ammunition;
    public GameObject bullet;

    void Start()
    {
    }

    void Awake()
    {
        //AudioSource.PlayClipAtPoint(selectSound, transform.position);
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
