using System.Collections;
using System.Collections.Generic;
using System.Data;
using Fungus;
using UnityEngine;

public class FlowchartManagement_Scene4 : MonoBehaviour
{
    //this is for when the mc is at the bridge house of the old guy and is casting the detect/exorcise runes

    [SerializeField] GameObject detectRune;
    [SerializeField] GameObject exorciseRune;
    Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        flowchart = GetComponent<Flowchart>();
    }
    public void SetDetectRuneActive()
    {
        detectRune.SetActive(true);
    }

    public void OnDetectRuneDone()
    {
        StartCoroutine(AfterCastDetect());
    }
    private IEnumerator AfterCastDetect()
    {
        yield return new WaitForSeconds(4f);
        flowchart.ExecuteBlock("afterCastDetectionSpell");
    }
    public void SetExorciseRuneActive()
    {
        exorciseRune.SetActive(true);
    }
    public void OnExorciseRuneDone()
    {
        StartCoroutine(AfterCastExorcise());
    }
    private IEnumerator AfterCastExorcise()
    {
        yield return new WaitForSeconds(4f);
        flowchart.ExecuteBlock("afterExorciseSpell");
    }
}
