using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class StoryFX : MonoBehaviour
{
    //this script is for all the various visual effects you're going to need...

    [Header("Change BG To Teaset")]
    [SerializeField] SpriteRenderer backgroundToChangeToTeaset;
    [SerializeField] Sprite teasetBackground;

    public void ChangeBackgroundToTeaset()
    {
        //backgroundToChangeToTeaset.sprite = teasetBackground;
        Debug.Log("background changed, go back and uncomment real code later XD");
    }
    [Header("Change BG To Dunhuang")]
    [SerializeField] SpriteRenderer backgroundToChangeToDunhuang;
    [SerializeField] Sprite dunhuangBackground;
    public void ChangeBackgroundToDunhuang()
    {
        //backgroundToChangeToDunhuang.sprite = dunhuangBackground;
        Debug.Log("background changed, go back and uncomment real code later XD");
    }
    [Header("Change BG To Sunset")]
    [SerializeField] SpriteRenderer backgroundToChangeToSunset;
    [SerializeField] Sprite sunsetBackground;
    [SerializeField] Flowchart scene9Flowchart;
    public void ChangeBackgroundToSunset()
    {
        //backgroundToChangeToSunset.sprite = sunsetBackground;
        Debug.Log("background changed, go back and uncomment real code later XD");
        scene9Flowchart.ExecuteBlock("Sunset");
    }
}
