using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Switch : MonoBehaviour
{
    public GameManager gameManager;
    private Renderer renderer;

    public Node debugNode;

    // Start is called before the first frame update
    void Start()
    {
        
    }


   
    // Update is called once per frame
    void Update()
    {

       


        
        
    }

    public void PlayerInteract()
    {
        if(!gameManager.activeNode)
        {
            gameManager.previousNode = debugNode;
            gameManager.activeNode = debugNode.gameObject;
            gameManager.SetActiveCamera(gameManager.networkCamera);
            debugNode.SendMessage("SetActiveNode", debugNode.GetComponent<Node>());
            gameManager.player.GetComponent<StarterAssets.FirstPersonController>().enabled = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

  

    private void OnDrawGizmos()
    {
        //  Gizmos.DrawSphere(transform.position, interactionDistance);
    }
}
