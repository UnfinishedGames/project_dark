using UnityEngine;
using System.Runtime.InteropServices;

public class PadBasedController : PlayerController
{
    public string lookHorizontal;
    public string lookVertical;
    public string pushButton;

    protected override void Move()
    { 
        var horizontalDirection = Vector3.right * Input.GetAxis(playerAxisHorizontal);
        var verticalDirection = Vector3.forward * Input.GetAxis(playerAxisVertical);
        //Debug.Log("Direction: " + horizontalDirection.ToString("G4"));
        //Debug.Log("Input: " + Input.GetAxis(playerAxisHorizontal).ToString());
        var newDirection = (horizontalDirection + verticalDirection);
        transform.position += newDirection * speed * Time.deltaTime;  
        // check if we have some movement and play the assigned movement sound
        this.playerSoundManager.playMovementSound(newDirection);
    }

    protected override void Turning()
    {
        var newLookingDirection = new Vector3(Input.GetAxis(lookHorizontal), 0.0f, Input.GetAxis(lookVertical));
        if (!newLookingDirection.Equals(Vector3.zero))
        {
            //Debug.logger.Log ("new vector", newLookingDirection);
            transform.rotation = Quaternion.LookRotation(newLookingDirection);
        }
    }

    protected override void checkFireWeapon()
    {
        if (Input.GetButtonDown(pushButton))
        {
            fireWeapon();
        }
    }

    protected override void checkWeaponSwitch()
    {
        if (Input.GetButtonDown(switchWeaponButton))
        {
            switchWeapon();
        }
    }
}