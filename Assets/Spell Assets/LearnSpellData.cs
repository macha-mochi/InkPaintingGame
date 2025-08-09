using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LearnSpellData", menuName = "LearnSpellData")]
public class LearnSpellData : ScriptableObject
{
    public List<int> unlearnedSpells;
    public List<int> learnedSpells;
}
