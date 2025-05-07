using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FlowchartManagement_Scene9 : MonoBehaviour
{
    [SerializeField] GameObject lightRune;
    Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        flowchart = GetComponent<Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetLightRuneActive()
    {
        lightRune.SetActive(true);
    }

    public void OnLightRuneDone()
    {
        StartCoroutine(AfterCastLight());
    }
    private IEnumerator AfterCastLight()
    {
        yield return new WaitForSeconds(3.5f);
        flowchart.ExecuteBlock("AfterCastLight");
    }
    public void LeaveTemple()
    {
        //TODO do a fade transition
        flowchart.ExecuteBlock("Sunset");
    }
}
