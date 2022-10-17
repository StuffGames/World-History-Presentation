using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventClass: MonoBehaviour
{

    private Material sceneSkybox; //Skybox associated with the Event

    private AudioClip sceneMusic; //music associated with the Event

    //private name variable inherited from Object class

    //private variable for the 3D models of the world

    private int eventID = 0;

    public EventClass() {
        Debug.Log("Event Created!");
    }

    public EventClass(int id)
    {
        eventID = id;
    }
    public int getEventID() {
        return eventID;
    }
}
