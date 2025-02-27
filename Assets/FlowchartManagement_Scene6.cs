using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FlowchartManagement_Scene6 : MonoBehaviour
{
    [SerializeField] GameObject readEnergyRune;
    [SerializeField] GameObject shareEnergyRune;
    Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        flowchart = GetComponent<Flowchart>();
    }

    public void SetReadEnergyActive()
    {
        readEnergyRune.SetActive(true);
    }

    public void OnReadEnergyDone()
    {
        StartCoroutine(AfterCastRead());
    }
    private IEnumerator AfterCastRead()
    {
        yield return new WaitForSeconds(3.5f);
        flowchart.ExecuteBlock("AfterCastReadEnergy");
    }
    public void SetShareEnergyActive()
    {
        shareEnergyRune.SetActive(true);
    }
    public void OnShareEnergyDone()
    {
        StartCoroutine(AfterCastShare());
    }
    private IEnumerator AfterCastShare()
    {
        yield return new WaitForSeconds(3.5f);
        flowchart.ExecuteBlock("AfterCastShareEnergy");
    }
}
