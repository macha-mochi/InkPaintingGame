using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class MainManager : MonoBehaviour
{
    public static int progress = 0;
    public static int maxProgress = 0;
    public static int numPracticeCurrent = 0;
    public static int numLearnCurrent = 0;
    public static int cultivationLocation = -1;
    public static char cultivationMode; //can be 'p' or 'l'
    public static int activePostProcessingProfile = 0;

    public List<Location> locations = new List<Location>();
    [SerializeField] TextMeshProUGUI objective;

    public List<PostProcessProfile> PPProfiles = new List<PostProcessProfile>();
    [SerializeField] PostProcessVolume mainCameraPPVolume;

    private void Start()
    {
        maxProgress = Mathf.Max(maxProgress, progress);
        /*PlayerPrefs.SetInt("MaxProgress", Mathf.Max(PlayerPrefs.GetInt("MaxProgress"), progress));
        PlayerPrefs.SetInt("Progress", progress);
        PlayerPrefs.SetInt("NumPracticeCurrent", numPracticeCurrent);
        PlayerPrefs.SetInt("NumLearnCurrent", numLearnCurrent);*/
        LoadMainMap();
    }
    private void LoadMainMap()
    {
        Debug.Log("progress: " + progress);
        switch (progress)
        {
            case 0:
                locations[0].isUnlocked = true;
                locations[0].canProgressStory = true;
                Debug.Log("player at masters house");
                break;
            case 1:
                locations[0].isUnlocked = false;
                locations[1].isUnlocked = true;
                locations[1].canProgressStory = true;
                Debug.Log("player going down the mountain");
                break;
            case 2:
                locations[1].isUnlocked = false;
                locations[2].isUnlocked = true;
                locations[2].canProgressStory = true;
                Debug.Log("player arrives at their room in the city");
                break;
            case 3:
                locations[2].isUnlocked = false;
                locations[3].isUnlocked = true;
                locations[3].canProgressStory = true;
                Debug.Log("player at library, introduce to commissions + get info on first one");
                break;
            case 4:
                locations[3].isUnlocked = false;
                locations[4].isUnlocked = true;
                locations[4].canProgressStory = true;
                Debug.Log("first commission, player at bridge w old guy");
                break;
            case 5:
                locations[4].isUnlocked = false;

                //unlocked locations = room, library
                locations[2].isUnlocked = true; //room
                locations[2].canCultivate = true;
                locations[3].isUnlocked = true; //library
                locations[3].canCultivate = true;

                int practiceNeeded = 2;
                int learnNeeded = 2;
                numPracticeCurrent = Mathf.Min(numPracticeCurrent, practiceNeeded);
                numLearnCurrent = Mathf.Min(numLearnCurrent, learnNeeded);
                if(numPracticeCurrent == practiceNeeded && numLearnCurrent == learnNeeded)
                {
                    objective.text = "Story Progression Available: Harbor";

                    //still have other locations available, it just wont count extra
                    /*
                     * practice: random spell theyve done before
                     * learn: new spell, but if they try to do 'learn' again AFTER meeting criteria,
                     *      just do practice instead to save new spells for later
                     */
                    locations[5].isUnlocked = true;
                    locations[5].canProgressStory = true;

                    numPracticeCurrent = 0;
                    numLearnCurrent = 0;
                }
                else
                {
                    string text = "Practice Spells: " + numPracticeCurrent + "/" + practiceNeeded + "\n" +
                        "Learn Spells: " + numLearnCurrent + "/" + learnNeeded;
                    objective.text = text;
                }

                Debug.Log("[cultivate X times] then player at lake, on boat, unlock lake location");
                break;
            case 6:
                locations[5].isUnlocked = false;

                //unlocked locations = room, library, lake
                locations[2].isUnlocked = true; //room
                locations[2].canCultivate = true;
                locations[3].isUnlocked = true; //library
                locations[3].canCultivate = true;
                locations[5].isUnlocked = true; //lake
                locations[5].canCultivate = true;

                practiceNeeded = 2;
                learnNeeded = 1;
                numPracticeCurrent = Mathf.Min(numPracticeCurrent, practiceNeeded);
                numLearnCurrent = Mathf.Min(numLearnCurrent, learnNeeded);
                if (numPracticeCurrent == practiceNeeded && numLearnCurrent == learnNeeded)
                {
                    objective.text = "Story Progression Available: Tea Garden";

                    //still have other locations available, it just wont count extra
                    /*
                     * practice: random spell theyve done before
                     * learn: new spell, but if they try to do 'learn' again AFTER meeting criteria,
                     *      just do practice instead to save new spells for later
                     */
                    locations[6].isUnlocked = true;
                    locations[6].canProgressStory = true;

                    numPracticeCurrent = 0;
                    numLearnCurrent = 0;
                }
                else
                {
                    objective.text =
                        "Practice Spells: " + numPracticeCurrent + "/" + practiceNeeded + "\n" +
                        "Learn Spells: " + numLearnCurrent + "/" + learnNeeded;
                }

                Debug.Log("[cultivate X times] player goes to tea masters garden, does commission and buys tea, unlock location");
                break;
            case 7:
                locations[6].isUnlocked = false;
                locations[7].isUnlocked = true;
                locations[7].canProgressStory = true;
                Debug.Log("player goes to maple forest, unlock location");
                break;
            case 8:
                locations[7].isUnlocked = false;

                //unlocked locations = room, library, lake, tea garden, maple forest
                locations[2].isUnlocked = true; //room
                locations[2].canCultivate = true;
                locations[3].isUnlocked = true; //library
                locations[3].canCultivate = true;
                locations[5].isUnlocked = true; //lake
                locations[5].canCultivate = true;
                locations[6].isUnlocked = true; //tea garden
                locations[6].canCultivate = true;
                locations[7].isUnlocked = true; //maple forest
                locations[7].canCultivate = true;

                practiceNeeded = 1;
                learnNeeded = 1;
                numPracticeCurrent = Mathf.Min(numPracticeCurrent, practiceNeeded);
                numLearnCurrent = Mathf.Min(numLearnCurrent, learnNeeded);
                if (numPracticeCurrent == practiceNeeded && numLearnCurrent == learnNeeded)
                {
                    objective.text = "Story Progression Available: My Room";

                    //still have other locations available, it just wont count extra
                    /*
                     * practice: random spell theyve done before
                     * learn: new spell, but if they try to do 'learn' again AFTER meeting criteria,
                     *      just do practice instead to save new spells for later
                     */
                    locations[8].isUnlocked = true;
                    locations[8].canProgressStory = true;

                    numPracticeCurrent = 0;
                    numLearnCurrent = 0;
                }
                else
                {
                    objective.text =
                        "Practice Spells: " + numPracticeCurrent + "/" + practiceNeeded + "\n" +
                        "Learn Spells: " + numLearnCurrent + "/" + learnNeeded;
                }

                Debug.Log("[cultivate X times] player is at their room, mc realizes theyve been here for while");
                break;
            case 9:
                locations[8].isUnlocked = false;
                locations[9].isUnlocked = true;
                locations[9].canProgressStory = true;
                Debug.Log("player in desert, pretty AF");
                break;
            case 10:
                locations[9].isUnlocked = false;
                locations[10].isUnlocked = true;
                locations[10].canProgressStory = true;
                Debug.Log("player back at masters house, game ends");
                break;
            default:
                SceneManager.LoadScene(3); //go to credits
                break;
        }

        foreach(Location loc in locations)
        {
            loc.gameObject.SetActive(loc.isUnlocked);
        }

        mainCameraPPVolume.profile = PPProfiles[activePostProcessingProfile];
    }
}
