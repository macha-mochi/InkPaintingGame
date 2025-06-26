using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenUIManager : MonoBehaviour
{
    public void NewGame()
    {
        MainManager.progress = 0;
        MainManager.numLearnCurrent = 0;
        MainManager.numPracticeCurrent = 0;
        SceneManager.LoadScene(1);
    }
    public void ContinueGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenGallery()
    {
        SceneManager.LoadScene(4);
    }
    [Header("Settings")]
    [SerializeField] GameObject settingsPopup;
    public void OpenSettings()
    {
        settingsPopup.SetActive(true);
    }
    public void CloseSettings()
    {
        settingsPopup.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
