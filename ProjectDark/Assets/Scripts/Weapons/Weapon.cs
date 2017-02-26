using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Weapon : NetworkBehaviour
{
    public AvailableWeapons weaponType;
    public bool continuesFiring = false;

    public virtual void fire()
    {

    }

    public virtual void stop()
    {

    }

    public virtual void select()
    {
        
    }
}
