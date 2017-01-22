using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public AvailableWeapons weaponType;
    public bool continuesFiring = false;

    public virtual void fire()
    {
        
    }

    public virtual void select()
    {
        
    }
}
