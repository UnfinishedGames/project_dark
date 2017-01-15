﻿using UnityEngine;

public class MouseBasedController : MonoBehaviour
{
    public float speed = 6f;
    // The speed that the player will move at.
    public string playerAxisHorizontal;
    public string playerAxisVertical;
    public AudioSource stepSound;

    // The vector to store the direction of the player's movement.
    Vector3 movement;
    // Reference to the player's rigidbody.
    Rigidbody playerRigidbody;

    public int pushButton = 0;
    public Rigidbody weapon;
    public Transform weaponSlot;

    void Awake()
    {
        // Set up references.
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw(playerAxisHorizontal);
        float v = Input.GetAxisRaw(playerAxisVertical);

        // Move the player around the scene.
        Move(h, v);

        // Turn the player to face the mouse cursor.
        Turning();
        slashOut();
    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
        
        // check if we have some movement and play the assigned movement sound
        if (movement.magnitude > 0.1)
        {
            if (!stepSound.isPlaying)
            {
                stepSound.Play();
            }
        }
        else
        {
            stepSound.Stop();
        }
    }

    /// <summary>
    /// We turn the player object so that it will face the mouse pointer.
    /// </summary>
    void Turning()
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

    void slashOut()
    {
        if (Input.GetMouseButtonDown(pushButton))
        {
            //Debug.Log("BAM");
            Rigidbody weapon_inst;
            weapon_inst = Instantiate(weapon, weaponSlot.position, weaponSlot.rotation) as Rigidbody;
            //weapon_inst.AddExplosionForce(3, weaponSlot.position, 3);
            weapon_inst.AddForce(weaponSlot.forward * 1000);
        }
    }
}

