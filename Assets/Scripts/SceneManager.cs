using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public EventContentList e;

    //Process in which button gets selected.
    public void ButtonSelection(GameObject button){
        button.GetComponent<Button>().interactable = false;
        e.SwitchEvents(button.GetComponent<RectTransform>());
    }
}
