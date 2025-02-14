using System.Collections;
using System.Collections.Generic;
using Fungus;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class PracticeSpell : MonoBehaviour
{
    /*
     * problem: need a way to detect what % of the mask is filled in
     * can scan thru entire 2d array of the texture, if mask[i] is same color as editablemask[i] and the alpha at that pixel = 1
     * dont check every frame (might be slow?), check whenever the mouse stops for longer than a certain time (0.3?) or every half second
     * but if they stop for too long (like >3 sec) it should be a fail and then you restart
     */

    [SerializeField] MouseDraw md;
    [SerializeField] Texture2D runeMaskTex;
    Texture2D editableMaskTex;
    Color[] runeMask;
    Color[] editableMask;

    Vector3 prevMousePosition;
    Vector3 mousePositionDelta;
    float timeSinceMouseStopped = 0;

    float timeSinceLastCheck = 0;
    bool drawingStarted = false; //you shouldn't be checking if they fail if they havent even started LMAO
    bool runeCompleted = false;

    //calling a method by name on complete
    [Header("On Complete Stuff")]
    [SerializeField] GameObject callMethodOn;
    [SerializeField] string methodName;

    // Start is called before the first frame update
    void Start()
    {
        runeMask = runeMaskTex.GetPixels();
        prevMousePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(editableMaskTex == null)
        {
            editableMaskTex = md.GetEditableTexture();
        }
        if (!drawingStarted && !runeCompleted && Input.GetMouseButton(0)) //is dragging
        {
            drawingStarted = true;
        }
        if (drawingStarted)
        {
            timeSinceLastCheck += Time.deltaTime;

            mousePositionDelta = Input.mousePosition - prevMousePosition;
            if (mousePositionDelta.magnitude == 0)
            {
                timeSinceMouseStopped += Time.deltaTime;
            }
            else
            {
                timeSinceMouseStopped = 0;
            }
            prevMousePosition += mousePositionDelta;

            if (timeSinceLastCheck >= 0.5f || timeSinceMouseStopped >= 0.3f)
            {
                float propFilled = GetPercentFilled();
                Debug.Log("proportion filled: " + propFilled);
                if(propFilled >= 0.9)
                {
                    OnRuneCompleted();
                }
            }
            if (timeSinceMouseStopped >= 3f)
            {
                Reset();
            }
        }
    }
    private float GetPercentFilled()
    {
        editableMask = editableMaskTex.GetPixels();
        int numSame = 0;
        int total = 0;
        for(int i = 0; i < runeMask.Length; i++)
        {
            if (runeMask[i].a != 0){
                if (runeMask[i].a == editableMask[i].a) numSame++;
                total++;
            }
        }
        return ((float)numSame) / total;

    }
    private void Reset()
    {
        Debug.Log("failed bc waited for too long");
        drawingStarted = false;
        timeSinceLastCheck = 0;
        timeSinceMouseStopped = 0;
        md.ClearDrawableTexture();
    }
    public bool GetDrawingStarted()
    {
        return drawingStarted;
    }
    public void OnRuneCompleted()
    {
        Debug.Log("done practicing rune");
        drawingStarted = false;
        runeCompleted = true;
        md.SetCanDraw(false);

        if (callMethodOn != null)
        {
            callMethodOn.SendMessage(methodName);
        }
    }
}
