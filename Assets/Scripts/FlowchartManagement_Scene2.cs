using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class FlowchartManagement_Scene2 : MonoBehaviour
{
    //this is for when the mc is in their room practicing their first 2 runes

    [SerializeField] GameObject rune1;
    [SerializeField] GameObject rune2;
    Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        flowchart = GetComponent<Flowchart>();
    }
    public void SetFirstRuneActive()
    {
        rune1.SetActive(true);
    }

    public void OnFirstRuneDone()
    {
        StartCoroutine(MakeSecondRune());
    }
    private IEnumerator MakeSecondRune()
    {
        yield return new WaitForSeconds(3.5f);
        rune2.SetActive(true);
        Debug.Log("rune 1 done, set 2nd one active");
    }
    public void OnSecondRuneDone()
    {
        StartCoroutine(MoveOn());
    }
    private IEnumerator MoveOn()
    {
        yield return new WaitForSeconds(3.5f);
        flowchart.ExecuteBlock("afterRunes");
        Debug.Log("moved on to next part of story.");
    }
}
