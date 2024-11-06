using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public SpriteRenderer background;
    public Color blinkColor = Color.white;
    public float blinkDuration = 0.5f;

    private Color originalColor;

    private void Start()
    {
        if (background != null)
        {
            originalColor = background.color;
        }
    }

    public void Blink()
    {
        StartCoroutine(BlinkCoroutine());
    }

    private IEnumerator BlinkCoroutine()
    {
        if (background != null)
        {
            background.color = blinkColor;

            yield return new WaitForSeconds(blinkDuration);

            background.color = originalColor;
        }
    }
}

