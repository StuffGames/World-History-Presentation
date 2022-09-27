using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public EventContentList e;
    public List<Material> skyboxes;

    //If button is selected, turn off until other button selected from the events list
    public void ButtonSelection(GameObject button){
        button.GetComponent<Button>().interactable = false;
        e.SwitchEvents(button.GetComponent<RectTransform>());
    }
}
