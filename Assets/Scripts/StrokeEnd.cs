using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrokeEnd : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if (ContainsMouse() && s.IsMouseInMask() && Input.GetMouseButtonUp(0))
        {
            //then for the end, if the mouse is released within the thing and its in the texture its also good
            s.nextStroke();
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
