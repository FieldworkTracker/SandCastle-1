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
        if (Input.GetKeyUp(KeyCode.Space))
        {
            r.velocity = Vector2.up * speed;
        }
    }
}
