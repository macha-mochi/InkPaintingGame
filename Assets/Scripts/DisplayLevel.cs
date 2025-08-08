using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLevel : MonoBehaviour
{
    [SerializeField] List<GameObject> levels = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if(MainManager.cultivationLocation == -1)
        {
            //we are in story mode
            levels[MainManager.progress].SetActive(true);
        }
        else
        {
            levels[MainManager.cultivationLocation].SetActive(true);
            //need to disable all the fungus stuff in the scene and all the children of the scenes except background
            //activate separate canvas for drawing runes
              //reference the ones in script to see delays (anyway delay is 4f after the rune is first completed)
            //choose a random rune + display what it does on the screen
              //for practice: its just all random u can get repeats
              //for learn: it shows u the ones u havent done yet but if u run out of that it just starts over
            //make a spell prefab then change the correct textures
              //could probably pair the texture with the string describing what it does in a scriptable?
              //nvm learn spells do need their own prefabs
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
