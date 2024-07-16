using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Location : MonoBehaviour
{
    public string locationName;
    public bool isUnlocked;
    public bool canProgressStory;
    public bool canCultivate; //practice and learn

    [SerializeField] GameObject popup;
    [SerializeField] Button story;
    [SerializeField] Button practice;
    [SerializeField] Button learn;

    public void ShowPanelOnClick()
    {
        if (!popup.activeInHierarchy)
        {
            popup.SetActive(true);
            this.transform.SetAsLastSibling();
            story.interactable = canProgressStory;
            practice.interactable = canCultivate;
            learn.interactable = canCultivate;
        }
        else
        {
            popup.SetActive(false);
        }
    }
}
