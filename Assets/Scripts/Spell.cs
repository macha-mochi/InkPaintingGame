using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour
{
    /* DETECTING IF THEY'RE IN THE LINES
     * 1. if the mouse moves outside the masked texture of the character we count that as wrong
     * 2. if that happens they fail the entire character
     * 3. each character should have a onFail() and onComplete() method
     * 4. they should also fail if they start going backwards or stop for longer than a certain time
     * 5. for detecting going backward: can probably do if the velocity direction changes close to 180
     * 6. there is a start point and an end point for each stroke, plus some colliders in between
     * to make sure they're going in th right direction
     * 7. you have infinite time to start the first stroke but after that you have to start
     * each new one within a certain time(like 1 sec)
     * 8. maybe colliders 'blocking off' forbidden areas(ex: intersections with other strokes)
     * to ensure you have to finish this one...if all other strokes are blocked off then
     * you might not even need 'progress' colliders like the racing game
     */

    [SerializeField] Image mask;
    [SerializeField] MouseDraw md;

    [SerializeField] List<StrokeStart> starts;
    [SerializeField] List<StrokeEnd> ends;
    [SerializeField] List<GameObject> barriers;

    bool drawingStarted = false;
    bool shouldCountTimeInactive = false;
    [SerializeField] float timeBeforeFail = 3.0f;
    float timeSinceLastAction = 0;
    Texture2D rune;
    int currentStroke = 0;

    Vector2 previousMousePosition;
    Vector2 velocityDirection;
    Vector2 previousVelocityDirection;
    // Start is called before the first frame update
    void Start()
    {
        rune = mask.sprite.texture;
        md.SetCanDraw(false);

        previousMousePosition = Input.mousePosition;
        previousVelocityDirection = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (drawingStarted)
        {
            velocityDirection = (Vector2)Input.mousePosition - previousMousePosition;
            Debug.Log(Input.mousePosition + " " + previousMousePosition);
            Debug.Log(previousVelocityDirection + " " + velocityDirection);
            Debug.Log(Vector2.Angle(previousVelocityDirection, velocityDirection));
            if (!IsMouseInMask() && Input.GetMouseButton(0))
            {
                Debug.Log("failed bc was dragging out of bounds");
                Reset();
            }else if (timeSinceLastAction >= timeBeforeFail)
            {
                Debug.Log("failed bc too slow");
                Reset();
            }else if(Input.GetMouseButtonDown(0) && !starts[currentStroke].ContainsMouse())
            {
                Debug.Log("failed bc started a stroke where ur not supposed to");
                Reset();
            }else if (Input.GetMouseButtonUp(0) && !ends[currentStroke].ContainsMouse())
            {
                Debug.Log("failed bc released stroke early");
                Reset();
            }else if(Vector2.Angle(previousVelocityDirection, velocityDirection) > 160)
            {
                //should fail if you start going in the wrong direction...
                Reset(); //TODO BROKEN, PROBABLE SOLUTION: DONT UPDATE PREVIOUS POSITION/VELOCITY EVERY FRAME
            }
            if (shouldCountTimeInactive) timeSinceLastAction += Time.deltaTime;

            previousMousePosition = Input.mousePosition;
            previousVelocityDirection = velocityDirection;
        }
    }
    public void nextStroke()
    {
        /* PLAN: have two arrays, one for stroke starts and one for stroke ends
         * when you go to the next stroke: if its the last one then finish (call a method that can be overrode)
         * if its not the last one, increment a counter by one and set new ones to be active / restart the countdown
         * (can check if countdown is too long in set drawing started)
         */
        if (barriers[currentStroke] != null) barriers[currentStroke].SetActive(false);
        if (currentStroke == starts.Count-1) //finished
        {
            OnRuneCompleted();
        }
        else
        {
            currentStroke++;
            starts[currentStroke].gameObject.SetActive(true);
            ends[currentStroke].gameObject.SetActive(true);
            if (barriers[currentStroke] != null) barriers[currentStroke].SetActive(true);
            shouldCountTimeInactive = true;
        }
    }
    public bool IsMouseInMask()
    {
        Vector2 mousePos = md.GetMousePositionTexture();
        return rune.GetPixel((int)mousePos.x, (int)mousePos.y).a != 0;
    }
    public bool GetDrawingStarted()
    {
        return drawingStarted;
    }
    public void SetDrawingStarted(bool b) //also called whenever a new stroke is started
    {
        if(drawingStarted == false && b == true) //its the first stroke
        {
            md.SetCanDraw(true);
        }
        drawingStarted = b;
        shouldCountTimeInactive = false;
        timeSinceLastAction = 0;
    }
    public void OnRuneCompleted()
    {
        Debug.Log("rune completed");
        drawingStarted = false;
        md.SetCanDraw(false);
        //play all the fancy VFX :DDD
    }
    public void Reset()
    {
        starts[currentStroke].gameObject.SetActive(false);
        ends[currentStroke].gameObject.SetActive(false);
        if (barriers[currentStroke] != null) barriers[currentStroke].SetActive(false);
        drawingStarted = false;
        shouldCountTimeInactive = false;
        timeSinceLastAction = 0;
        currentStroke = 0;
        starts[0].gameObject.SetActive(true);
        ends[0].gameObject.SetActive(true);
        if (barriers[0] != null) barriers[0].SetActive(true);
        md.ClearDrawableTexture();
        md.SetCanDraw(false);
    }
}
