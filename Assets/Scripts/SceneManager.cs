using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public EventContentList e;
    public List<Material> skyboxes;

    private int i = 1;
    private float lerpTime = 0.9f;

    private bool mFlag = false;

    private Material m;

    void Start() {
        m = new Material(RenderSettings.skybox);
    }

    void Update(){
        SkyBoxChange();
    }

    //If button is selected, turn off until other button selected from the events list
    public void ButtonSelection(GameObject button){
        button.GetComponent<Button>().interactable = false;
        e.SwitchEvents(button.GetComponent<RectTransform>());
        //m = new Material(RenderSettings.skybox);
        m.name = "Temporary Material";
        RenderSettings.skybox = m;
        
        i++;
        if (i >= skyboxes.Count) i = 0;
        mFlag = true;
    }

    float lTime = 0; //counting from interpolation start to end

    //Changes the skybox over time
    private void SkyBoxChange(){
        if (mFlag){
            m.Lerp(m, skyboxes[i], lerpTime * Time.deltaTime);
            DynamicGI.UpdateEnvironment();
            lTime += lerpTime * Time.deltaTime;
        }
        if (lTime >= 1.5){
            mFlag = false;
            lTime = 0;
        }
    }
}
