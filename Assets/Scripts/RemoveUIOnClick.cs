using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class RemoveUIOnClick : MonoBehaviour, IPointerClickHandler
{
    //TODO appraoch doesnt work u will have to fade buttons, scroll, and text separately UGHHHH
    bool faded = false;
    bool inProgress = false;
    [SerializeField] Image[] buttons;
    [SerializeField] Image[] scrollBG;
    [SerializeField] TextMeshProUGUI scrollText;

    public void OnPointerClick(PointerEventData p)
    {
        Debug.Log(faded + " " + inProgress);
        if (!faded && !inProgress)
        {
            Debug.Log("fading out");
            StartCoroutine(FadeOut());
            inProgress = true;
        }
        else if (faded && !inProgress)
        {
            Debug.Log("fading in");
            StartCoroutine(FadeIn());
            inProgress = true;
        }
    }
    private IEnumerator FadeIn()
    {
        foreach (Image i in buttons) i.gameObject.SetActive(true);
        foreach(Image i in scrollBG) i.gameObject.SetActive(true);
        scrollText.gameObject.SetActive(true);

        float alpha = 0f;
        while (alpha < 1f)
        {
            alpha += 0.01f;
            Color c;
            foreach (Image i in buttons)
            {
                c = i.color;
                i.color = new Color(c.r, c.g, c.b, Mathf.Min(0.7f, alpha));
            }
            foreach (Image i in scrollBG)
            {
                c = i.color;
                i.color = new Color(c.r, c.g, c.b, alpha);
            }
            c = scrollText.color;
            scrollText.color = new Color(c.r, c.g, c.b, alpha);

            yield return null;
        }
        Debug.Log("fade in done");
        inProgress = false;
        faded = false;
    }
    private IEnumerator FadeOut()
    {
        float alpha = 1f;
        while (alpha > 0f)
        {
            alpha -= 0.01f;
            Color c;
            foreach (Image i in buttons)
            {
                c = i.color;
                i.color = new Color(c.r, c.g, c.b, Mathf.Min(0.7f, alpha));
            }
            foreach (Image i in scrollBG)
            {
                c = i.color;
                i.color = new Color(c.r, c.g, c.b, alpha);
            }
            c = scrollText.color;
            scrollText.color = new Color(c.r, c.g, c.b, alpha);

            yield return null;
        }
        Debug.Log("fade out done");
        inProgress = false;
        faded = true;

        foreach (Image i in buttons) i.gameObject.SetActive(false);
        foreach (Image i in scrollBG) i.gameObject.SetActive(false);
        scrollText.gameObject.SetActive(false);
    }
}
