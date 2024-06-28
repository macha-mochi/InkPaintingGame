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
        MainManager.instance.progressAndUpdateMap();
    }
}
