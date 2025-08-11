using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.Rendering.PostProcessing;

public class StoryFX : MonoBehaviour
{
    //this script is for all the various visual effects you're going to need...

    [Header("Change BG To Teaset")]
    [SerializeField] SpriteRenderer backgroundToChangeToTeaset;
    [SerializeField] Sprite teasetBackground;

    public void ChangeBackgroundToTeaset()
    {
        backgroundToChangeToTeaset.sprite = teasetBackground;
        backgroundToChangeToTeaset.transform.localScale = new Vector3(1.04f, 1.04f, 1);
    }
    [Header("Change BG To Dunhuang")]
    [SerializeField] SpriteRenderer backgroundToChangeToDunhuang;
    [SerializeField] Sprite dunhuangBackground;
    public void ChangeBackgroundToDunhuang()
    {
        backgroundToChangeToDunhuang.sprite = dunhuangBackground;
        backgroundToChangeToDunhuang.transform.localScale = new Vector3(1.03f, 1.03f, 1);
    }
    [Header("Change BG To Sunset")]
    [SerializeField] SpriteRenderer backgroundToChangeToSunset;
    [SerializeField] Sprite sunsetBackground;
    [SerializeField] Flowchart scene9Flowchart;
    public void ChangeBackgroundToSunset()
    {
        backgroundToChangeToSunset.sprite = sunsetBackground;
        backgroundToChangeToSunset.transform.localScale = new Vector3(0.99f, 0.99f, 1);
    }

    [Header("Change Post Processing Volume Weights")]
    [SerializeField] List<PostProcessVolume> volumes;
    public void ChangePostProcessing_GrayToPale()
    {
        StartCoroutine(Blend(0.3f, 0, 1));
    }
    public void ChangePostProcessing_PaleToColor()
    {
        StartCoroutine(Blend(0.3f, 1, 2));
    }
    private IEnumerator Blend(float speedMultiplier, int oldV, int newV)
    {
        PostProcessVolume changeFrom = volumes[oldV];
        PostProcessVolume changeTo = volumes[newV];

        while(changeTo.weight < 1)
        {
            changeFrom.weight -= Time.deltaTime * speedMultiplier;
            changeTo.weight += Time.deltaTime * speedMultiplier;
            yield return null; //makes coroutine wait just one frame
        }
        changeFrom.weight = 0;
        changeTo.weight = 1;

        MainManager.activePostProcessingProfile = newV;
    }
}
