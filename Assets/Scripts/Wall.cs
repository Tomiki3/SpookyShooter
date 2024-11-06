using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.MazeTouch();
        }
    }
}
