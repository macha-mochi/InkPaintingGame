using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpellData", menuName = "SpellData")]
public class SpellData : ScriptableObject
{
    public Sprite runeSprite;
    public string description;
    //a particle system for effects
}
