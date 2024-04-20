using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public Rigidbody2D r;
    public float speed = 5;
    private bool isLanded = false;

    // Assign this in the inspector to the transform of your parking position GameObject
    public Transform parkingPosition;

    void Update()
    {
        // Control the plane only if it has not landed
        if (!isLanded)
        {
            ControlPlane();
        }

        // Check for input to take off if the plane has landed
        if (isLanded && Input.GetKey(KeyCode.Space)) // Using space bar for take off
        {
            TakeOff();
        }
    }

    private void ControlPlane()
    {
        //Arrow keys to control movement of plane
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement += Vector2.up * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement += Vector2.down * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement += Vector2.left * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement += Vector2.right * speed;
        }

        r.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the plane collides with an object tagged as "Island"
        if (collision.gameObject.CompareTag("Island"))
        {
            ParkPlane();
        }
    }

    private void ParkPlane()
    {
        isLanded = true; // Mark the plane as landed
        r.velocity = Vector2.zero; // Stop the plane
        r.isKinematic = true; // Disable physics interactions

        // Reposition the plane to the "parking" position, if specified
        if (parkingPosition != null)
        {
            this.transform.position = parkingPosition.position;
            this.transform.rotation = parkingPosition.rotation;
        }
    }

    public void TakeOff()
    {
        isLanded = false;
        r.isKinematic = false; // Re-enable physics interactions
        // Optionally, apply a small upward force to simulate takeoff
        r.AddForce(new Vector2(0, 100f));
    }
}
