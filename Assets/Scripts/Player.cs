using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 4f;
    public GameObject projectilePrefab;
    public Transform shootPoint; // Point from where the projectile will be shot

    private float screenLeftBound;
    private float screenRightBound;

    private void Start()
    {
        // Calculate screen bounds in world space based on the camera
        float halfPlayerWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        screenLeftBound = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + halfPlayerWidth;
        screenRightBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - halfPlayerWidth;
    }

    private void Update()
    {
            HandleMovement();
            HandleShooting();
    }

    void HandleMovement()
    {
        // Player movement
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, 0);
        transform.Translate(moveVelocity * Time.deltaTime);

        // Clamp the player's position within the screen bounds
        float clampedX = Mathf.Clamp(transform.position.x, screenLeftBound, screenRightBound);
        transform.position = new Vector2(clampedX, transform.position.y);
    }

    void HandleShooting()
    {
        // Check if spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate a new projectile at the shoot point's position
        Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
    }
}
