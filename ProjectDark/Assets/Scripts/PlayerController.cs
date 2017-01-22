using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 6f;
    // The speed that the player will move at.
    public string playerAxisHorizontal;
    public string playerAxisVertical;
    public AudioSource stepSound;
    public Transform weaponSlot;
    public WeaponStash weaponStash;
    public AvailableWeapons startWeapon;
    public string switchWeaponButton;

    protected GameObject weapon;
    protected PlayerSoundManager playerSoundManager;
    protected Weapon currentWeapon;

    protected virtual void Awake()
    {
        this.playerSoundManager = new PlayerSoundManager(this.stepSound);
        selectWeapon(startWeapon.ToString());
    }

    private void Update()
    {
        checkWeaponSwitch();

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        Move();
        Turning();
        checkFireWeapon(currentWeapon.continuesFiring);
    }

    protected virtual void Move()
    {
        
    }

    protected virtual void Turning()
    {
        
    }

    protected virtual void checkFireWeapon(bool continuesFiring)
    {
    }

    protected virtual void checkWeaponSwitch()
    {

    }

    protected void fireWeapon()
    {
        this.currentWeapon.fire();
    }

    protected void selectWeapon(string weaponName)
    {
        GameObject weapon = this.weaponStash.getWeapon(weaponName, this.weaponSlot);
        this.currentWeapon = weapon.GetComponent<Weapon>();
        this.currentWeapon.select();
    }

    protected void switchWeapon()
    {
        AvailableWeapons newWeapon = AvailableWeapons.EnergyPulseGun;
        switch (currentWeapon.weaponType)
        {
        case AvailableWeapons.EnergyPulseGun:
            newWeapon = AvailableWeapons.Flashlight;
            break;
        case AvailableWeapons.Flashlight:
            newWeapon = AvailableWeapons.LaserGun;
            break;
        case AvailableWeapons.LaserGun:
            newWeapon = AvailableWeapons.EnergyPulseGun;
            break;
        }
        Destroy(currentWeapon.gameObject);
        selectWeapon(newWeapon.ToString());
    }
}
