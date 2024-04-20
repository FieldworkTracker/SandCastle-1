using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public Rigidbody2D r;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Plane";
    }

    // Update is called once per frame
    void Update()
    {
        //Arrow keys to control movement of plane
        if (Input.GetKey(KeyCode.UpArrow))
        {
            r.velocity = new Vector2(0, speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            r.velocity = new Vector2(0, -speed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            r.velocity = new Vector2(-speed, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            r.velocity = new Vector2(speed, 0);
        }
        else
        {
            r.velocity = new Vector2(0, 0);
        }
    }
}
