using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrokeStart : MonoBehaviour
{
    LearnSpell s;
    RectTransform rt;
    Vector2 centerPos_Screen;
    float timeSinceStart = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        s = transform.parent.GetComponent<LearnSpell>();

        Vector3[] v = new Vector3[4];
        rt = GetComponent<RectTransform>();
        rt.GetWorldCorners(v);
        centerPos_Screen = new Vector2((v[1].x + v[2].x) / 2, (v[0].y + v[1].y) / 2);
    }

    void Update()
    {
        if(ContainsMouse() && s.IsMouseInMask() && Input.GetMouseButtonDown(0))
        {
            //mouse is in this thing's recangle and mouse is in the rune and mouse just went down
            s.SetDrawingStarted(true);
            gameObject.SetActive(false);
        }
        Animate();
    }
    public bool ContainsMouse()
    {
        Vector2 mousePosition_Screen = Input.mousePosition;
        bool containsMouse = Mathf.Abs(mousePosition_Screen.x - centerPos_Screen.x) <= rt.rect.width / 2 && Mathf.Abs(mousePosition_Screen.y - centerPos_Screen.y) <= rt.rect.height;
        return containsMouse;
    }
    private void Animate()
    {
        //min: 0.8 max: 1.3 equation: 0.25 * cos(t - 1.77) + 1.05
        float scaleFactor = 0.25f * Mathf.Cos(timeSinceStart - 1.77f) + 1.05f;
        transform.localScale = new Vector3(scaleFactor, scaleFactor);

        timeSinceStart += Time.deltaTime;
    }
}
