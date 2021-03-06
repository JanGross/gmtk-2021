using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public CinemachineVirtualCamera activeCamera;
    public CinemachineVirtualCamera networkCamera;
    public CinemachineVirtualCamera playerCamera;
    public GameObject activeNode;
    public Node previousNode;
    public bool networkView = false;

    public bool playerHasUSB = false;
    public bool playerHasBattery = false;

    private bool exiting = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetActiveCamera(CinemachineVirtualCamera vCam)
    {
        if (vCam == networkCamera && activeCamera != networkCamera && activeCamera != playerCamera)
        {
            exiting = true;
        }
        else
        {
            exiting = false;
        }

        vCam.Priority = 20;
        activeCamera.Priority = 0;
        activeCamera = vCam;

        networkView = (!exiting && activeCamera == networkCamera) ? true : false;
        
    }

    // Update is called once per frame
    void Update()
    {
        networkView = (activeCamera == networkCamera) ? true : false;
    }

    private void FixedUpdate()
    {
        //Leave network view with x
        if (Keyboard.current.xKey.wasPressedThisFrame && networkView)
        {
            player.GetComponent<StarterAssets.FirstPersonController>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            SetActiveCamera(playerCamera);
            activeNode.GetComponent<Node>().DisableNode();
            activeNode = null;
        }
    }
}
