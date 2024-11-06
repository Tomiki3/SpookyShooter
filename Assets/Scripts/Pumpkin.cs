using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    private BackgroundManager backgroundManager;
    private GameManager gameManager;
    private float bottomEdge;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        backgroundManager = FindObjectOfType<BackgroundManager>();
        bottomEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y <= bottomEdge)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (backgroundManager != null)
        {
            backgroundManager.Blink();
        }

        if (gameManager != null)
        {
            gameManager.PumpkinAttack();
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.AddScore(10);
        }
    }
}
