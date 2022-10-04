using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public EventContentList e;
    public List<Material> skyboxes;

    private int event_id = 1;
    private float lerpTime = 0.9f;

    private bool mFlag = false;

    private Material m;

    void Start() {
        m = new Material(RenderSettings.skybox); //Creating a copy of the skybox material
    }

    void Update(){
        SkyBoxChange();
    }

    //CHANGE TO SEPARATE OBJECTS LATER,
    //list of objects that conatin music, environment, lighting, text, etc

    // Called from the Editor when the Button is selected
    // 
    public void ButtonSelection(GameObject button){
        button.GetComponent<Button>().interactable = false;
        e.SwitchEvents(button.GetComponent<RectTransform>());

        //Find the index of the button in the list of events
        for(int i = 0; i < e.events.Count; i++){
            if (e.events[i].gameObject == button) event_id = i;
        }
        m.name = "Temporary Material";
        RenderSettings.skybox = m;

        if (event_id >= skyboxes.Count) event_id = 0;
        lTime = 0;
        mFlag = true;
    }

    float lTime = 0; //counting from interpolation start to end

    //Changes the skybox over time
    private void SkyBoxChange(){
        if (mFlag){
            m.Lerp(m, skyboxes[event_id], lerpTime * Time.deltaTime);
            DynamicGI.UpdateEnvironment();
            lTime += lerpTime * Time.deltaTime;
        }
        if (lTime >= 1.5){
            mFlag = false;
            lTime = 0;
        }
    }
}
