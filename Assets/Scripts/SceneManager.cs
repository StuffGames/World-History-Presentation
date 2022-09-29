using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public EventContentList e;
    public List<Material> skyboxes;

    private int i = 0;
    private float lerpTime = 0.1f;

    void Update(){
    }

    //If button is selected, turn off until other button selected from the events list
    public void ButtonSelection(GameObject button){
        button.GetComponent<Button>().interactable = false;
        e.SwitchEvents(button.GetComponent<RectTransform>());
        SkyBoxChange();
    }

    //ISSUE SkyBoxChange gets called once from the button click but does not update the interpolation every frame
    //find some way to move the interpolation to Update function

    //Changes the skybox based on the button clicked
    public void SkyBoxChange(){
        Material changeM = new Material(RenderSettings.skybox);
        RenderSettings.skybox = changeM;
        changeM.Lerp(RenderSettings.skybox, skyboxes[i], lerpTime);
        //When interpolation finished...
        //RenderSettings.skybox = skyboxes[i];
        i++;
        DynamicGI.UpdateEnvironment();
        if (i >= skyboxes.Count) i = 0;
    }
}
