using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum AvailableWeapons {
    FLASHLIGHT,
    ENERGY_PULSE
}

public class WeaponStash : MonoBehaviour
{
    public List<GameObject> weaponList;

    public GameObject getWeapon(AvailableWeapons weapon, Transform weaponSlot)
    {
        GameObject weapon_inst = null;
        switch (weapon)
        {
        case AvailableWeapons.ENERGY_PULSE:
            weapon_inst = Instantiate(weaponList[0], weaponSlot.position, weaponSlot.rotation) as GameObject;
            break;
        }
        return weapon_inst;
    }

}
