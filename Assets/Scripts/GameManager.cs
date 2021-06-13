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
    public GameObject activeNode;
    public Node previousNode;
    public bool networkView = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetActiveCamera(CinemachineVirtualCamera vCam)
    {   
        vCam.Priority = 20;
        activeCamera.Priority = 0;
        activeCamera = vCam;

        if(!activeCamera == networkCamera) { networkView = false; }
           
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        //Leave network view with x
        if (Keyboard.current.xKey.wasPressedThisFrame && networkView)
        {
            player.GetComponent<StarterAssets.FirstPersonController>().enabled = true;
            SetActiveCamera(networkCamera);
            activeNode.GetComponent<Node>().DisableNode();
            activeNode = null;
        }
    }
}
