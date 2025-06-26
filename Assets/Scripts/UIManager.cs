using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class UIManager : MonoBehaviour
{
    public void SetScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void progressAndUpdateMap()
    {
        MainManager.progress++;
        if(MainManager.progress == 6 || MainManager.progress == 9)
        {
            MainManager.numPracticeCurrent = 0;
            MainManager.numLearnCurrent = 0;
        }
        PlayerPrefs.SetInt("Progress", MainManager.progress);
    }
    public void finishCultivation()
    {
        MainManager.cultivationLocation = -1;
        if(MainManager.cultivationMode == 'p')
        {
            MainManager.numPracticeCurrent++;
            Debug.Log(MainManager.numPracticeCurrent);
        }else if(MainManager.cultivationMode == 'l')
        {
            MainManager.numLearnCurrent++;
            Debug.Log(MainManager.numLearnCurrent);
        }
    }
    public void goPractice(int loc)
    {
        MainManager.cultivationMode = 'p';
        MainManager.cultivationLocation = loc;
    }
    public void goLearn(int loc)
    {
        MainManager.cultivationMode = 'l';
        MainManager.cultivationLocation = loc;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    [Header("Settings")]
    [SerializeField] GameObject settingsPopup;
    [SerializeField] DialogInput sayDialog;
    public void OpenSettings()
    {
        settingsPopup.SetActive(true);
        sayDialog.SetCanAdvanceNextLine(false);
    }
    public void CloseSettings()
    {
        settingsPopup.SetActive(false);
        sayDialog.SetCanAdvanceNextLine(true);
    }
}
