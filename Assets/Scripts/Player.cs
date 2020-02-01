using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    public GameObject weaponSlot;
    public bool canShoot;

    private Vector3 moveDirection;
    private Vector3 direction;
    private Vector3 previousPosition;
    private GameObject primaryGun;
    private GameObject secondaryGun;

    private void Start()
    {
        previousPosition = transform.position;
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontalMove, verticalMove, 0f);
        moveDirection = transform.position - previousPosition;

        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90f;

            Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1.0f);
        }

        previousPosition = transform.position;
        transform.Translate(direction * movementSpeed * Time.deltaTime, Space.World);
    }

    public void HandleNewGun(GameObject currentWeapon)
    {
        canShoot = true;
        if (!primaryGun)
        {
            primaryGun = currentWeapon;
            GameObject newWeapon = Instantiate(currentWeapon, weaponSlot.transform.position, currentWeapon.transform.rotation);
            newWeapon.transform.SetParent(weaponSlot.transform);
        }
        else
        {
            secondaryGun = currentWeapon;
        }
    }
}
