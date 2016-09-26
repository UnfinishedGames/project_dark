using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float TurnSpeed = 180f;
    public float Speed = 12f;
    public string MovementAxisName;
    public string TurnAxisName;

    private new Rigidbody rigidbody;
    private float turnInputValue;
    private float movementInputValue;

    private void OnEnable()
    {
        // When the tank is turned on, make sure it's not kinematic.
        rigidbody.isKinematic = false;

        // Also reset the input values.
        movementInputValue = 0f;
        turnInputValue = 0f;
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
        movementInputValue = Input.GetAxis(MovementAxisName);
        turnInputValue = Input.GetAxis(TurnAxisName);
    }

    private void FixedUpdate()
    {
        // Adjust the rigidbodies position and orientation in FixedUpdate.
        Move();
        Turn();
    }
    
    private void Move()
    {
        // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.forward * movementInputValue * Speed * Time.deltaTime;

        // Apply this movement to the rigidbody's position.
        rigidbody.MovePosition(rigidbody.position + movement);
    }

    private void Turn()
    {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = turnInputValue * TurnSpeed * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        rigidbody.MoveRotation(rigidbody.rotation * turnRotation);
    }
}
