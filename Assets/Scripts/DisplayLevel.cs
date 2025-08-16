using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using UnityEngine.Rendering.PostProcessing;

public class DisplayLevel : MonoBehaviour
{
    [Header("Story Scenes")]
    [SerializeField] List<GameObject> levels = new List<GameObject>();

    [Header("Stuff to Remove")]
    [SerializeField] List<GameObject> fungusUIObjects;
    [SerializeField] GameObject storyScenes;

    [Header("Rune Stuff")]
    [SerializeField] Canvas spellCanvas;
    [SerializeField] RectTransform runeSpawnLocation;

    [SerializeField] GameObject spellPrefab;
    [SerializeField] SpellData[] spellDataList; //all spells, each one has an index, prolly alphabetically
    [SerializeField] int[] practiceSpells;
    [SerializeField] LearnSpellData learnSpellData;

    [Header("Other Stuff")]
    [SerializeField] GameObject cultivationDoneButton;

    [Header("Change Post Processing Volume Weights")]
    [SerializeField] List<PostProcessVolume> volumes;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < volumes.Count; i++)
        {
            if (i == MainManager.activePostProcessingProfile)
            {
                volumes[i].weight = 1;
            }
            else volumes[i].weight = 0;
        }

        if (MainManager.cultivationLocation == -1)
        {
            //we are in story mode
            levels[MainManager.progress].SetActive(true);
        }
        else
        {
            levels[MainManager.cultivationLocation].SetActive(true);
            DisableStoryGameObjects();
            spellCanvas.gameObject.SetActive(true);

            //choose a random rune + display what it does on the screen
            //for practice: its just all random u can get repeats
            //for learn: it shows u the ones u havent done yet but if u run out of that it just starts over

            //make a spell prefab then change the correct textures
            //could probably pair the texture with the string describing what it does in a scriptable?
            //nvm learn spells do need their own prefabs
            if (MainManager.cultivationMode == 'p')
            {
                DisplaySpell_Practice();
            }
            else if(MainManager.cultivationMode == 'l')
            {
                DisplaySpell_Learn();
            }
        }
        
    }
    void DisplaySpell_Practice()
    {
        SpellData s = spellDataList[practiceSpells[Random.Range(0, practiceSpells.Length)]];
        GameObject newSpell = Instantiate(spellPrefab, runeSpawnLocation);
        PracticeSpell ps = newSpell.GetComponent<PracticeSpell>();
        ps.spellAttributes = s;
        ps.callMethodOn = this.gameObject;
        ps.methodName = "ShowCultivationCompleteButton";
    }
    public void ShowCultivationCompleteButton()
    {
        StartCoroutine("ShowCCB", 4f);
    }
    IEnumerator ShowCCB(float delay)
    {
        yield return new WaitForSeconds(delay);
        cultivationDoneButton.SetActive(true);
    }
    void DisplaySpell_Learn()
    {
        if(learnSpellData.unlearnedSpells.Count == 0)
        {
            foreach(int i in learnSpellData.learnedSpells)
            {
                learnSpellData.unlearnedSpells.Add(i);
            }
            learnSpellData.learnedSpells.Clear();
        }
        int numUnlearned = learnSpellData.unlearnedSpells.Count;
        int index = Random.Range(0, numUnlearned);
        int spellNumber = learnSpellData.unlearnedSpells[index];
        while(spellNumber == learnSpellData.lastLearnedSpell)
        {
            index = Random.Range(0, numUnlearned);
            spellNumber = learnSpellData.unlearnedSpells[index];
        }
        GameObject prefabToSpawn = spellDataList[spellNumber].prefab;
        if(prefabToSpawn == null)
        {
            //Debug.Log("NO PREFAB ASSIGNED TO CURRENT LEARN SPELL");
            return;
        }
        GameObject newSpell = Instantiate(prefabToSpawn, runeSpawnLocation);
        LearnSpell ls = newSpell.GetComponent<LearnSpell>();
        ls.callMethodOn = this.gameObject;
        ls.methodName = "ShowCultivationCompleteButton";
        learnSpellData.unlearnedSpells.RemoveAt(index);
        learnSpellData.learnedSpells.Add(spellNumber);
        learnSpellData.lastLearnedSpell = spellNumber;
    }
    void DisableStoryGameObjects()
    {
        foreach(GameObject o in fungusUIObjects){
            o.SetActive(false);
        }
        foreach(Flowchart f in storyScenes.GetComponentsInChildren<Flowchart>())
        {
            f.gameObject.SetActive(false);
        }
        foreach(Canvas c in storyScenes.GetComponentsInChildren<Canvas>())
        {
            c.gameObject.SetActive(false);
        }
    }
}
