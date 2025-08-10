using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpellData", menuName = "SpellData")]
public class SpellData : ScriptableObject
{
    public Sprite runeSprite;
    public string description;
    public GameObject prefab; //only applies if its a learn spell
    //a particle system for effects
}
