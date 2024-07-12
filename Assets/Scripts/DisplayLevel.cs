using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLevel : MonoBehaviour
{
    [SerializeField]
    List<GameObject> levels = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        levels[MainManager.progress].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
