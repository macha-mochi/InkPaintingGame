using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GalleryManager : MonoBehaviour
{
    int currentIndex = 0;
    [SerializeField] GameObject[] paintings;
    [SerializeField] string[] placeNames;
    [SerializeField] TextMeshProUGUI placeName;

    private void Start()
    {
        placeName.text = placeNames[currentIndex];
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Left();
        }else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Right();
        }
    }
    public void Left()
    {
        paintings[currentIndex].SetActive(false);
        if (currentIndex == 0) currentIndex = paintings.Length - 1;
        else currentIndex--;
        paintings[currentIndex].SetActive(true);
        placeName.text = placeNames[currentIndex];

    }
    public void Right()
    {
        paintings[currentIndex].SetActive(false);
        if (currentIndex == paintings.Length - 1) currentIndex = 0;
        else currentIndex++;
        paintings[currentIndex].SetActive(true);
        placeName.text = placeNames[currentIndex];
    }
    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }
    /*
     * you should be able to use both clicking and the arrow keys to go between paintings
     * clicking not on a button will remove the ui but if you use arrow key it should still work and the ui should stay down
     */
}
