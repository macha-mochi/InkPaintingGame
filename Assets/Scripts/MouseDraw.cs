using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseDraw : MonoBehaviour
{
    /*
     * THE PLAN
     * 1. make an empty/transparent texture2d the same size as the image of the rune
     * 2. set that texture to be the image
     * 3. when the mouse moves, set pixels within certain distance of mouse to 1
     * 4. apply texture
     * 5. should work...?
     */

    [SerializeField] int pixelBrushRadius;

    Texture2D texture;
    RawImage mask;
    Vector3 prevMousePosition;
    Vector2 mousePositionDelta;
    Vector2 mousePos_Texture;
    Vector2 textureBottomLeftPos_Screen;

    Color clear = new Color(0, 0, 0, 0);
    Color[] transparent;
    Color black = new Color(0, 0, 0, 1);

    bool canDraw = true;

    void Start()
    {
        texture = new Texture2D(728, 1490);
        transparent = new Color[728 * 1490];
        for(int i = 0; i < transparent.Length; i++)
        {
            transparent[i] = clear;
        }
        texture.SetPixels(transparent, 0);
        texture.Apply();
        mask = GetComponent<RawImage>();
        mask.texture = texture;

        prevMousePosition = Input.mousePosition;

        Vector3[] v = new Vector3[4];
        GetComponent<RectTransform>().GetWorldCorners(v);
        textureBottomLeftPos_Screen = v[0];
    }

    // Update is called once per frame
    void Update()
    {
        mousePositionDelta = Input.mousePosition - prevMousePosition;

        Vector2 mousePos_Screen = Input.mousePosition; //bottom left is 0, 0, mouse position relative to screen
        mousePos_Texture = mousePos_Screen - textureBottomLeftPos_Screen;

        if (canDraw && Input.GetMouseButton(0) && mousePositionDelta.magnitude != 0)
        {
            /*Vector2 mousePos_Screen = Input.mousePosition; //bottom left is 0, 0, mouse position relative to screen

            Vector3[] v = new Vector3[4];
            GetComponent<RectTransform>().GetWorldCorners(v);
            Vector2 textureBottomLeftPos_Screen = v[0];

            mousePos_Texture = mousePos_Screen - textureBottomLeftPos_Screen;*/
            Vector2 prevMousePos_Texture = (Vector2)prevMousePosition - textureBottomLeftPos_Screen;

            //texture.SetPixel((int)mousePos_Texture.x, (int)mousePos_Texture.y, black);

            SetPixelsInCircle(texture, (int)mousePos_Texture.x, (int)mousePos_Texture.y, pixelBrushRadius, black);
            if (mousePositionDelta.magnitude >= pixelBrushRadius)
                SetPixelsInWideLine(texture, prevMousePos_Texture.x, prevMousePos_Texture.y, mousePos_Texture.x, mousePos_Texture.y, pixelBrushRadius * 2, black);

            texture.Apply();
        }
        prevMousePosition = Input.mousePosition;
    }
    void SetPixelsInCircle(Texture2D tex, int x, int y, int r, Color c)
    {
        int w = tex.width;
        int h = tex.height;
        for(int i = x-r; i <= x+r; i++)
        {
            for(int j = y-r; j <= y+r; j++)
            {
                if(i < 0 || i >= w || j < 0 || j >= h)
                {
                    //skip
                }
                else
                {
                    if ((i - x) * (i - x) + (j - y) * (j - y) <= r * r)
                    {
                        //is in the circle
                        tex.SetPixel(i, j, c);
                    }
                }
            }
        }
    }
    void SetPixelsInWideLine(Texture2D tex, float x1, float y1, float x2, float y2, int lineWidth, Color c)
    {
        float dx = x2 - x1;
        float dy = y2 - y1;
        float adx = Mathf.Abs(dx);
        float ady = Mathf.Abs(dy);

        float theta = Mathf.Atan(ady / adx);
        float cos = lineWidth / 2 * Mathf.Cos(Mathf.PI / 2 - theta);
        float sin = lineWidth / 2 * Mathf.Sin(Mathf.PI / 2 - theta);

        if (x1 <= x2 && y1 <= y2) //q1
        {
            float x = x1 - cos;
            float y = y1 + sin;

            if(adx >= ady)
            {
                while (y >= y1 - sin)
                {
                    SetPixelsInLine(tex, x, y, x + dx, y + dy, c);
                    x += dy / dx;
                    y -= 1;
                }
            }
            else
            {
                while (x <= x1 + cos)
                {
                    SetPixelsInLine(tex, x, y, x + dx, y + dy, c);
                    x += 1;
                    y -= dx / dy;
                }
            }
        }
        else if(x1 <= x2 && y1 >= y2) //q4
        {
            float x = x1 + cos;
            float y = y1 + sin;

            if (adx >= ady)
            {
                while (y >= y1 - sin)
                {
                    SetPixelsInLine(tex, x, y, x + dx, y + dy, c);
                    x -= ady / adx;
                    y -= 1;
                }
            }
            else
            {
                while (x >= x1 - cos)
                {
                    SetPixelsInLine(tex, x, y, x + dx, y + dy, c);
                    x -= 1;
                    y -= adx / ady;
                }
            }
        }
        else if(x1 >= x2 && y1 <= y2) //q2
        {
            float x = x1 - cos;
            float y = y1 - sin;

            if (adx >= ady)
            {
                while (y <= y1 + sin)
                {
                    SetPixelsInLine(tex, x, y, x + dx, y + dy, c);
                    x += ady / adx;
                    y += 1;
                }
            }
            else
            {
                while (x <= x1 + cos)
                {
                    SetPixelsInLine(tex, x, y, x + dx, y + dy, c);
                    x += 1;
                    y += adx / ady;
                }
            }
        }
        else if(x1 >= x2 && y1 > y2) //q3
        {
            float x = x1 - cos;
            float y = y1 + sin;

            if (adx >= ady)
            {
                while (y >= y1 - sin)
                {
                    SetPixelsInLine(tex, x, y, x + dx, y + dy, c);
                    x += ady / adx;
                    y -= 1;
                }
            }
            else
            {
                while (x <= x1 + cos)
                {
                    SetPixelsInLine(tex, x, y, x + dx, y + dy, c);
                    x += 1;
                    y -= adx / ady;
                }
            }
        }
    }
    void SetPixelsInLine(Texture2D tex, float x1, float y1, float x2, float y2, Color c)
    {
        float dx = x2 - x1;
        float dy = y2 - y1;

        float x = x1;
        float y = y1;
        if(Mathf.Abs(dx) >= Mathf.Abs(dy))
        {
            float m = Mathf.Abs(dy / dx);
            while((x2 > x1 && x <= x2) || (x2 < x1 && x >= x2))
            {
                tex.SetPixel((int)x, (int)y, c);
                if (x1 < x2) x += 1;
                else x -= 1;
                if (y1 < y2) y += m;
                else y -= m;
            }
        }
        else
        {
            float m = Mathf.Abs(dx / dy);
            while ((y2 > y1 && y <= y2) || (y2 < y1 && y >= y2))
            {
                tex.SetPixel((int)x, (int)y, c);
                if (y1 < y2) y += 1;
                else y -= 1;
                if (x1 < x2) x += m;
                else x -= m;
            }
        }
    }
    public Vector2 GetMousePositionTexture()
    {
        return mousePos_Texture;
    }
    public void ClearDrawableTexture()
    {
        texture.SetPixels(transparent, 0);
        texture.Apply();
    }
    public bool GetCanDraw()
    {
        return canDraw;
    }
    public void SetCanDraw(bool b)
    {
        canDraw = b;
    }
}
