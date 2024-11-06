using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Maze : MonoBehaviour
{
    public float speed = 2f;

    public void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
