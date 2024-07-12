using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static int progress = 0;
    public static int numPracticeCurrent = 0;
    public static int numLearnCurrent = 0;

    public List<Location> locations = new List<Location>();

    private void Start()
    {
        PlayerPrefs.SetInt("Progress", progress);
        PlayerPrefs.SetInt("NumPracticeCurrent", numPracticeCurrent);
        PlayerPrefs.SetInt("NumLearnCurrent", numLearnCurrent);
        LoadMainMap();
    }
    private void LoadMainMap()
    {
        Debug.Log("progress: " + progress);
        switch (progress)
        {
            case 0:
                locations[0].isUnlocked = true;
                Debug.Log("player at masters house");
                break;
            case 1:
                locations[0].isUnlocked = false;
                locations[1].isUnlocked = true;
                Debug.Log("player going down the mountain");
                break;
            case 2:
                locations[1].isUnlocked = false;
                locations[2].isUnlocked = true;
                Debug.Log("player arrives at their room in the city");
                break;
            case 3:
                locations[2].isUnlocked = false;
                locations[3].isUnlocked = true;
                Debug.Log("player at library, introduce to commissions + get info on first one");
                break;
            case 4:
                locations[3].isUnlocked = false;
                locations[4].isUnlocked = true;
                Debug.Log("first commission, player at bridge w old guy");
                break;
            case 5:

                //TODO: practice/learn x times, unlocked locations = room, library

                locations[4].isUnlocked = false;
                locations[5].isUnlocked = true;
                Debug.Log("[cultivate X times] then player at lake, on boat, unlock lake location");
                break;
            case 6:

                //TODO: practice/learn x times, unlocked locations = room, library, lake

                locations[5].isUnlocked = false;
                locations[6].isUnlocked = true;
                Debug.Log("[cultivate X times] go to library for another commission, get info on first one");
                break;
            case 7:
                locations[6].isUnlocked = false;
                locations[7].isUnlocked = true;
                Debug.Log("player at tea masters garden, does commission and buys tea, unlock location");
                break;
            case 8:
                locations[7].isUnlocked = false;
                locations[8].isUnlocked = true;
                Debug.Log("player goes to maple forest, unlock location");
                break;
            case 9:

                //TODO: practice/learn x times, unlocked locations = room, library, lake, tea garden, maple forest

                locations[8].isUnlocked = false;
                locations[9].isUnlocked = true;
                Debug.Log("[cultivate X times] player is at their room, mc realizes theyve been here for while");
                break;
            case 10:
                locations[9].isUnlocked = false;
                locations[10].isUnlocked = true;
                Debug.Log("player in desert, pretty AF");
                break;
            case 11:
                locations[10].isUnlocked = false;
                locations[11].isUnlocked = true;
                Debug.Log("player back at masters house, game ends");
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
