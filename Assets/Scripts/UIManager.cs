using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void SetScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void progressAndUpdateMap()
    {
        MainManager.progress++;
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
}
