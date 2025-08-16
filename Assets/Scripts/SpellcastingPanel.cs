using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellcastingPanel : MonoBehaviour
{
    public bool isFading = false;
    float originalAlpha = 0.6f;
    float dAlpha = 1f;
    Image img;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFading)
        {
            Color c = img.color;
            img.color = new Color(c.r, c.g, c.b, c.a - dAlpha * Time.deltaTime);
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
