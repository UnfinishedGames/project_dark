﻿using UnityEngine;

public class PadBasedController : MonoBehaviour
{
    public float speed = 6f;
    // The speed that the player will move at.
    public string playerAxisHorizontal;
    public string playerAxisVertical;

    public string lookHorizontal;
    public string lookVertical;

    public string pushButton;
    public Rigidbody weapon;
    public Transform weaponSlot;
    
    Vector3 movement;
    // The vector to store the direction of the player's movement.
    //Rigidbody playerRigidbody;
    // Reference to the player's rigidbody.

    void Awake()
    {
        // Set up references.
        //playerRigidbody = GetComponent<Rigidbody>(); 
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
        var newDirection = (Vector3.right * Input.GetAxis(playerAxisHorizontal) + Vector3.forward * Input.GetAxis(playerAxisVertical)).normalized;    
        //Debug.logger.Log ("LookHorizontal", Input.GetAxisRaw (lookHorizontal));
        //Debug.logger.Log ("LookVertical", Input.GetAxisRaw (lookVertical));
        var newLookingDirection = new Vector3(Input.GetAxis(lookHorizontal), 0.0f, Input.GetAxis(lookVertical));
        //newLookingDirection.Normalize();
        if (!newLookingDirection.Equals(Vector3.zero))
        {
            Turning(newLookingDirection);
        }
        Move(newDirection);

        slashOut();
    }

    void Move(Vector3 newDirection)
    { 
        transform.position += newDirection * speed * Time.deltaTime;  
    }

    // Update is called once per frame
    void Turning(Vector3 newDirection)
    {
        //Debug.logger.Log ("new vector", newDirection);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    void slashOut()
    {
        if (Input.GetButtonDown(pushButton))
        {
            Debug.Log("BAM");
            Rigidbody weapon_inst;
            weapon_inst = Instantiate(weapon, weaponSlot.position, weaponSlot.rotation) as Rigidbody;
            //weapon_inst.AddExplosionForce(3, weaponSlot.position, 3);
            weapon_inst.AddForce(weaponSlot.forward * 1000);
        }
    }
}