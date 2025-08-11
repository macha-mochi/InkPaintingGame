using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    KeyCode[] kc;
    // Start is called before the first frame update
    void Start()
    {
        kc = new KeyCode[] { KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3,
            KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9};
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i <= 9; i++)
        {
            if (Input.GetKeyDown(kc[i]))
            {
                Debug.Log("CHANGED MAIN MANAGER PROGRESS COUNT TO " + i);
                MainManager.progress = i;
                return;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("CHANGED PRACTICE AND LEARN COUNTS TO 2");
            MainManager.numPracticeCurrent = 2;
            MainManager.numLearnCurrent = 2;
        }
    }
}
