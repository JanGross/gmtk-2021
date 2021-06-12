using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Switch : MonoBehaviour
{
    public GameManager gameManager;
    public float interactionDistance = 10;
    private Renderer renderer;

    public Node debugNode;

    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }


   
    // Update is called once per frame
    void Update()
    {

       


        if (renderer.isVisible)
        {
            if (Vector3.Distance(transform.position, gameManager.player.transform.position) < interactionDistance) {
                //Debug.Log("Switch is visible and in range");
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    gameManager.SetActiveCamera(1);
                    debugNode.SetActiveNode();
                }
            }
        }
        
    }

  

    private void OnDrawGizmos()
    {
        //  Gizmos.DrawSphere(transform.position, interactionDistance);
    }
}
