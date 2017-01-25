using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum AvailableWeapons {
    EnergyPulseGun,
    Flashlight,
    LaserGun
}

public class WeaponStash : MonoBehaviour
{
    public List<GameObject> weaponList;

    public GameObject getWeapon(AvailableWeapons weaponToFetch, Transform weaponSlot)
    {
        GameObject weapon = null;
        foreach (GameObject item in weaponList)
        {
            if (item.name.Contains(weaponToFetch.ToString()))
            {
                weapon = item;
            }
        }

        if (weapon == null)
        {
            throw new TypeLoadException("Weapon " + weaponToFetch.ToString() + " not found!");
        }
            
        GameObject newWeapon = Instantiate(weapon, weaponSlot.position, weaponSlot.rotation) as GameObject;
        newWeapon.transform.parent = weaponSlot;
        return newWeapon;
    }

}
