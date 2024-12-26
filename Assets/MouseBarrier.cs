using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MouseBarrier : MonoBehaviour, IPointerEnterHandler
{
    Spell s;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("entered");
        if(Input.GetMouseButton(0)) s.Reset(); //only reset if they're also dragging
    }

    // Start is called before the first frame update
    void Start()
    {
        s = GetComponentInParent<Spell>();
    }
}
