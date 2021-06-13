using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RobotArmController : MonoBehaviour
{

    public bool isInUse = false;

    public GameManager gameManager;
    public Grapparoni grabber;
    public CinemachineVirtualCamera localCamera;
    public GameObject target;
    public float armSpeed = 1;
    public float armRotationSpeed = 10;
    public Vector3 targetConstraints;
    public GameObject targetMarker;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        target.GetComponent<Animator>().speed = 1f;
    }

    private void Update()
    {
        targetMarker.transform.position = new Vector3(target.transform.position.x, transform.position.y + .5f, target.transform.position.z);
    }

    public void InteractNode(Node pre)
    {
        gameManager.SetActiveCamera(localCamera);
        isInUse = true;
        target.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isInUse) { return; }

        //return to network view with x
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            gameManager.SetActiveCamera(gameManager.networkCamera);
            target.GetComponent<Animator>().enabled = true;
            isInUse = false;
            gameManager.previousNode.SetActiveNode();
        }

        //return to network view with x
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            grabber.GrabClosest();
        }

        //Hoch/Runter
        if (Keyboard.current.ctrlKey.isPressed && target.transform.position.y > transform.position.y)
        {
            target.transform.localPosition += Vector3.down * Time.deltaTime * armSpeed;
        }

        if (Keyboard.current.shiftKey.isPressed && target.transform.localPosition.y < targetConstraints.y)
        {
            target.transform.localPosition += Vector3.up * Time.deltaTime * armSpeed;
        }

        //Debug.Log(-targetConstraints.z);
        //Left/Right
        if (Keyboard.current.aKey.isPressed && target.transform.localPosition.z > -targetConstraints.z)
        {
            target.transform.localPosition += Vector3.back * Time.deltaTime * armSpeed;
        }

        if (Keyboard.current.dKey.isPressed && target.transform.localPosition.z < targetConstraints.z)
        {
            target.transform.localPosition += Vector3.forward * Time.deltaTime * armSpeed;
        }

        //Left/Right
        if (Keyboard.current.qKey.isPressed)
        {
            transform.Rotate(0.0f, armRotationSpeed * Time.deltaTime, 0.0f, Space.Self);
        }   

        if (Keyboard.current.eKey.isPressed)
        {
            transform.Rotate(0.0f, -armRotationSpeed * Time.deltaTime, 0.0f, Space.Self);
        }

        //Forwards/Backwards
        if (Keyboard.current.wKey.isPressed && target.transform.localPosition.x > -targetConstraints.x)
        {
            target.transform.localPosition += Vector3.left * Time.deltaTime * armSpeed;
        }

        if (Keyboard.current.sKey.isPressed && target.transform.localPosition.x < -3.5f)
        {
            target.transform.localPosition += Vector3.right * Time.deltaTime * armSpeed;
        }
    }
}
