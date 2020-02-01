using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform weaponSlot;
    public GameObject projectilePrefab;
    public float projectileForce = 20f;

    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && player.canShoot)
        {
            HandleShoot();
        }
    }

    private void HandleShoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, weaponSlot.position, weaponSlot.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(weaponSlot.up * projectileForce, ForceMode2D.Impulse);
    }
}
