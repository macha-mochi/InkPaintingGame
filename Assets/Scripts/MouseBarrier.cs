using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MouseBarrier : MonoBehaviour, IPointerEnterHandler
{
    LearnSpell s;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("entered");
        if(Input.GetMouseButton(0)) s.ResetSpell("Mouse deviated from current stroke!"); //only reset if they're also dragging
    }

    // Start is called before the first frame update
    void Start()
    {
        s = GetComponentInParent<LearnSpell>();
    }
}
