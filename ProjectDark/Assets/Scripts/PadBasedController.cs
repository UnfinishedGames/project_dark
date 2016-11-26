using UnityEngine;
using System.Runtime.InteropServices;

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
        Move();
        Turning();
        slashOut();
    }

    void Move()
    { 
        var horizontalDirection = Vector3.right * Input.GetAxis(playerAxisHorizontal);
        var verticalDirection = Vector3.forward * Input.GetAxis(playerAxisVertical);
        //Debug.Log("Direction: " + horizontalDirection.ToString("G4"));
        //Debug.Log("Input: " + Input.GetAxis(playerAxisHorizontal).ToString());
        var newDirection = (horizontalDirection + verticalDirection);
        transform.position += newDirection * speed * Time.deltaTime;  
    }

    void Turning()
    {
        var newLookingDirection = new Vector3(Input.GetAxis(lookHorizontal), 0.0f, Input.GetAxis(lookVertical));
        if (!newLookingDirection.Equals(Vector3.zero))
        {
            //Debug.logger.Log ("new vector", newLookingDirection);
            transform.rotation = Quaternion.LookRotation(newLookingDirection);
        }
    }

    void slashOut()
    {
        if (Input.GetButtonDown(pushButton))
        {
            //Debug.Log("BAM");
            Rigidbody weapon_inst;
            weapon_inst = Instantiate(weapon, weaponSlot.position, weaponSlot.rotation) as Rigidbody;
            //weapon_inst.AddExplosionForce(3, weaponSlot.position, 3);
            weapon_inst.AddForce(weaponSlot.forward * 1000);
        }
    }
}