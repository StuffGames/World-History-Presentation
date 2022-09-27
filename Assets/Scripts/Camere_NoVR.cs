//Camera Rotation used from https://gist.github.com/KarlRamstedt/407d50725c7b6abeaf43aee802fdd88e
//This script is used for 3D camera movement to test features before testing with VR equipment

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camere_NoVR : MonoBehaviour
{

    private Camera cam; // Camera component of GameObject
    private Vector2 rotation = Vector2.zero; // vector equal to (0,0)
    
    public float sensitivity; // sensitivity changed in the editor
    public float yRotationLimit; // rotation limit set in the editor
    public float camSpeed; // camera speed set in the editor

    void Start()
    {
        cam = gameObject.GetComponent<Camera>(); //Gets the camera component
    }

    void Update()
    {
        CameraMovement();

        CameraRotation();
    }

    //Moves the camera based on the input (WASD)
    void CameraMovement(){
        float speed = camSpeed * Time.deltaTime; // takes preset float from the editor and makes it consistent with Time.deltaTime
        float moveX = Input.GetAxis("Horizontal"); //A, D Input
        float moveY = Input.GetAxis("Vertical"); //W, S Input
        float moveZ = Input.GetAxis("Jump"); // Space, LeftCtrl Input

        transform.position += ((transform.forward * moveY)+(transform.right * moveX)+(Vector3.up * moveZ)) * speed; // Change transform based on input on the correct axis
    }

    //First Person Camera Movement
    void CameraRotation(){
        //Camera Rotation
        rotation.x += Input.GetAxis("Mouse X") * sensitivity; //Mouse sensitivity X
        rotation.y += Input.GetAxis("Mouse Y") * sensitivity; //Mouse sensitivity Y
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit); //Constrains Y rotation to predetermined limit

        Quaternion xQ = Quaternion.AngleAxis(rotation.x,Vector3.up); //Rotate camera along vertical axis based on Mouse Movement X
        Quaternion yQ = Quaternion.AngleAxis(rotation.y, Vector3.left); //Rotate Camera along horizontal axis based on Movement Y

        transform.localRotation = xQ * yQ; //Change camera rotation based on both rotation values from above
    }
}