using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
