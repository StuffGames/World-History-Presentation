using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventContentList : MonoBehaviour
{

    public List<RectTransform> events;
    private RectTransform tr;

    void Start()
    {
        tr = gameObject.GetComponent<RectTransform>();
        
        for (int i = 0; i < tr.childCount; i++){
            events.Add(tr.GetChild(i).GetComponent<RectTransform>());
            if (i == 0) {
                events[i].anchoredPosition3D = new Vector3(0f, -25f, 0f);
                continue;
            }
            events[i].anchoredPosition3D = new Vector3(0f, events[i - 1].anchoredPosition3D.y - 35f, 0f);
        }
    }
}
