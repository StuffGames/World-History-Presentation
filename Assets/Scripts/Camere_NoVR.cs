//Camera Rotation used from https://gist.github.com/KarlRamstedt/407d50725c7b6abeaf43aee802fdd88e
//This script is used for 3D camera movement to test features before testing with VR equipment

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camere_NoVR : MonoBehaviour
{

    private Camera cam;
    private Vector2 rotation = new Vector2(0,0);
    
    public float sensitivity;
    public float yRotationLimit;
    public float camSpeed;
    
    
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        //Mouse Properties
        bool inGame = true;
        if (Input.GetKeyDown(KeyCode.Escape)) inGame = false;

        if (inGame) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }else {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        bool raycast = Physics.Raycast(ray, out hit, 100f);
        //Debug.Log("Raycast hit?: " + raycast);
        if (raycast)
            Debug.Log(hit.transform.name);
        

        //Lateral Movement
        if (Input.GetKey(KeyCode.W)){
            transform.position += transform.forward * camSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)){
            transform.position += transform.forward * -camSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)){
            transform.position += transform.right * -camSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)){
            transform.position += transform.right * camSpeed * Time.deltaTime;
        }

        //Vertical Movement
        if (Input.GetKey(KeyCode.Space)){
            transform.position += transform.up * camSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftControl)){
            transform.position += transform.up * -camSpeed * Time.deltaTime;
        }

        //Camera Rotation
        rotation.x += Input.GetAxis("Mouse X") * sensitivity;
        rotation.y += Input.GetAxis("Mouse Y") * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);

        Quaternion xQ = Quaternion.AngleAxis(rotation.x,Vector3.up);
        Quaternion yQ = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.localRotation = xQ * yQ;
    
    }
}
