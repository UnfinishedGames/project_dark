using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
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
        selectWeapon(startWeapon);
    }

    public override void OnStartLocalPlayer()
    {
        var mainMesh = GetComponentInChildren<MeshRenderer>();
        mainMesh.material.color = Color.blue;
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
        if(!isLocalPlayer)
        {
            return;
        }

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

    [Command]
    protected void CmdFireWeapon(bool startFiring)
    {
        if (startFiring)
        {
            this.currentWeapon.fire();
        }
        else
        {
            this.currentWeapon.stop();
        }
    }

    protected void selectWeapon(AvailableWeapons weaponToSelect)
    {
        GameObject weapon = this.weaponStash.getWeapon(weaponToSelect, this.weaponSlot);
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
        selectWeapon(newWeapon);
    }
}
