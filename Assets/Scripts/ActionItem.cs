using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActionItem
{
    public enum ObjectiveType
    {
        Story,
        Practice,
        Learn
    }

    public ObjectiveType type;

    [Header("Story")]
    public Location location; //the quest marker that will appear on the map

    [Header("Practice")]
    public int numPracticeRequired;

    [Header("Learn")]
    public int numLearnRequired;
}
