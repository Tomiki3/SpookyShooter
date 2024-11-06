using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoStep1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<TutorialManager>().ShowNextStep();
        }

        if (other.CompareTag("Projectile"))
        {
            FindObjectOfType<TutorialManager>().ShowNextStep();
        }

        Destroy(gameObject);
    }

}
