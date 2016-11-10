using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float TurnSpeed = 180f;
    public float speed = 6f;            // The speed that the player will move at.
    public string HorizontalAxisName;
    public string VerticalAxisName;

    private new Rigidbody rigidbody;
    private float verticalValue;
    private float horizontalValue;
    private Vector3 movement;                   // The vector to store the direction of the player's movement.
    
    private void OnEnable()
    {
        // When the tank is turned on, make sure it's not kinematic.
        rigidbody.isKinematic = false;

        // Also reset the input values.
        horizontalValue = 0f;
        verticalValue = 0f;
    }


    private void OnDisable()
    {
        // When the tank is turned off, set it to kinematic so it stops moving.
        rigidbody.isKinematic = true;
    }

    // Use this for initialization
    void Start()
    {

    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Store the value of both input axes.
        horizontalValue = Input.GetAxis(HorizontalAxisName);
        verticalValue = Input.GetAxis(VerticalAxisName);
    }

    private void FixedUpdate()
    {
        // Adjust the rigidbodies position and orientation in FixedUpdate.
        Move();
        //Turn();
    }
    
    private void Move()
    {
        // Set the movement vector based on the axis input.
        movement.Set(horizontalValue, 0f, verticalValue);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        rigidbody.MovePosition(transform.position + movement);
    }

    private void Turn()
    {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = verticalValue * TurnSpeed * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        rigidbody.MoveRotation(rigidbody.rotation * turnRotation);
    }
}
