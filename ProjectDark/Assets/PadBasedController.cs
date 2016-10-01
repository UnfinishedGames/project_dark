using UnityEngine;

public class PadBasedController : MonoBehaviour
{
    public float speed = 6f;            // The speed that the player will move at.
    public string playerAxisHorizontal;
    public string playerAxisVertical;

    public string LookHorizontal;
    public string LookVertical;

    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.

    void Awake()
    {
        // Set up references.
        playerRigidbody = GetComponent<Rigidbody>();
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
    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }

    // Update is called once per frame
    void Turning()
    {
        // We are going to read the input every frame
        Vector3 vNewInput = new Vector3(Input.GetAxis(LookHorizontal), Input.GetAxis(LookVertical), 0.0f);

        // Only do work if meaningful
        if (vNewInput.sqrMagnitude < 0.1f)
        {
            return;
        }

        // Apply the transform to the object  
        var angle = Mathf.Atan2(Input.GetAxis(LookHorizontal), Input.GetAxis(LookVertical)) * Mathf.Rad2Deg;
        playerRigidbody.MoveRotation(Quaternion.Euler(0, angle, 0));
    }
}