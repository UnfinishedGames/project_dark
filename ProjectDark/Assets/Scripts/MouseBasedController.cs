using UnityEngine;
using System.Net;
using System.ComponentModel;

public class MouseBasedController : PlayerController
{
    // The vector to store the direction of the player's movement.
    Vector3 movement;
    // Reference to the player's rigidbody.
    Rigidbody playerRigidbody;
    public int pushButton = 0;


    protected override void Awake()
    {
        base.Awake();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    protected override void Move()
    {
        float h = Input.GetAxisRaw(playerAxisHorizontal);
        float v = Input.GetAxisRaw(playerAxisVertical);
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
        
        this.playerSoundManager.playMovementSound(movement);
    }

    /// <summary>
    /// We turn the player object so that it will face the mouse pointer.
    /// </summary>
    protected override void Turning()
    {
        // TODO: We might want to catch the mouse in a circle, so the plyer object will not change its looking direction when it is moving.
        var playerPlane = new Plane(Vector3.up, transform.position);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            var targetPoint = ray.GetPoint(hitdist);
            var targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            playerRigidbody.MoveRotation(targetRotation);

            // use the following to add a turning speed - might be useful in the future?
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        }
    }

    protected override void checkFireWeapon(bool continuesFiring)
    {
        if (continuesFiring)
        {
            if (Input.GetMouseButton(pushButton))
            {
                CmdFireWeapon(true);
            }
            if (Input.GetMouseButtonUp(pushButton))
            {
                CmdFireWeapon(false);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(pushButton))
            {
                CmdFireWeapon(true);
            }
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

