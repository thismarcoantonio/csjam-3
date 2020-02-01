using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed;

    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        this.HandleMovement(movement);
    }

    private void HandleMovement(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movementSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.Instance.RemoveLife(10);
            Destroy(gameObject);

            AudioController.Instance.PlaySound(AudioController.Instance.enemyDeath);
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            GameController.Instance.AddScore(1);
            Destroy(gameObject);

            AudioController.Instance.PlaySound(AudioController.Instance.enemyDeath);
        }
    }
}
