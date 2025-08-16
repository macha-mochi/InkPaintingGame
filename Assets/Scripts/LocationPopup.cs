using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationPopup : MonoBehaviour
{
    private static LocationPopup current = null;
    // Start is called before the first frame update
    private bool check = false;
    void OnEnable()
    {
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!check)
        {
            check = true;
            if (current == null || current == this) current = this;
            else
            {
                current.gameObject.SetActive(false);
                current = this;
            }
        }
    }
}
