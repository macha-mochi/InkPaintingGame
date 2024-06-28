using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int progress = 0;
    public List<ActionItem> storyline = new List<ActionItem>();

    public int numPracticeCurrent;
    public int numLearnCurrent;

    public List<Location> locations = new List<Location>();

    public void progressAndUpdateMap()
    {
        progress++;
        LoadMainMap();
    }
    private void LoadMainMap()
    {
        switch (progress)
        {
            case 0:

                break;
            case 1:
                Debug.Log("going to forest path from masters house");
                //set old quest marker to inactive and make next one active
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }

        //dont forget to do the colors

        foreach(Location loc in locations)
        {
            loc.gameObject.SetActive(loc.isUnlocked);
        }
    }
}
