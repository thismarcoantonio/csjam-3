using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    public float movementSpeed;
    public GameObject currentWeapon; 

    private Transform player;
    private Rigidbody2D rb;
    private Vector2 direction;
    private float rotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        direction = player.transform.position - transform.position;
        rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 130;
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        rb.rotation = rotation;
        rb.MovePosition((Vector2)transform.position + (direction * movementSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player playerInstance = collision.gameObject.GetComponent<Player>();
            playerInstance.HandleNewGun(currentWeapon);
            Destroy(gameObject);
        }
    }
}
