using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity;

    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rig.velocity = new Vector2(-velocity * Time.deltaTime, rig.velocity.y);
        }
        else
        {
            rig.velocity = new Vector2(0, rig.velocity.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rig.velocity = new Vector2(velocity * Time.deltaTime, rig.velocity.y);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rig.velocity = new Vector2(rig.velocity.x, velocity * Time.deltaTime);
        }
        else
        {
            rig.velocity = new Vector2(rig.velocity.x, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rig.velocity = new Vector2(rig.velocity.x, -velocity * Time.deltaTime);
        }
    }
}
