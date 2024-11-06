using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;

    private void Update()
    {
        // Move the projectile upwards
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        // Destroy the projectile when it goes off-screen
        Destroy(gameObject);
    }
}
