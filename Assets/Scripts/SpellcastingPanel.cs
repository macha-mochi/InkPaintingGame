using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellcastingPanel : MonoBehaviour
{
    public bool isFading;
    float originalAlpha = 0.6f;
    float dAlpha = 0.06f;
    Image img;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFading)
        {
            Color c = img.color;
            img.color = new Color(c.r, c.g, c.b, c.a - dAlpha);
            if (img.color.a <= 0) isFading = false;
        }
    }
    public void ResetAlpha()
    {
        Color c = img.color;
        img.color = new Color(c.r, c.g, c.b, originalAlpha);
        isFading = false;
    }
}
