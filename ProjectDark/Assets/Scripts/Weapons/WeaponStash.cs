using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum AvailableWeapons {
    EnergyPulseGun,
    Flashlight,
    LaserGun
}

public class WeaponStash : MonoBehaviour {
    public List<GameObject> weaponList;

    public GameObject getWeapon(string weaponName, Transform weaponSlot)
    {
        GameObject weapon = null;
        foreach (GameObject item in weaponList)
        {
            if (item.name.Contains(weaponName))
            {
                weapon = item;
            }
        }

        if (weapon == null)
        {
            throw new TypeLoadException("Weapon " + weaponName + " not found!");
        }
            
        GameObject newWeapon = Instantiate(weapon, weaponSlot.position, weaponSlot.rotation) as GameObject;
        newWeapon.transform.parent = weaponSlot;
        return newWeapon;
    }

}
