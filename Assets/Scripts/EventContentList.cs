using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventContentList : MonoBehaviour
{

    public List<RectTransform> events; // Keeps a list of the buttons from the content space of the scroll view
    private RectTransform tr; // The RectTrasnform of this object

    void Start()
    {
        //Creates a list of the Buttons avaiblable
        tr = gameObject.GetComponent<RectTransform>();
        
        //Iterate through every child to set it's position
        for (int i = 0; i < tr.childCount; i++){
            events.Add(tr.GetChild(i).GetComponent<RectTransform>());

            //If it is the first child then set its position to the top
            if (i == 0) {
                events[i].anchoredPosition3D = new Vector3(0f, -25f, 0f);
                continue;
            }
            events[i].anchoredPosition3D = new Vector3(0f, events[i - 1].anchoredPosition3D.y - 35f, 0f);
        }
    }

    //Turn interactable property on for all buttons except the one that just got pressed
    //This is to turn on the previous button that got pressed and was set to off
    public void SwitchEvents (RectTransform button) {
        foreach (RectTransform rt in events){
            if (rt == button){
                continue;
            }
            rt.GetComponent<Button>().interactable = true;
        }
    }
}
