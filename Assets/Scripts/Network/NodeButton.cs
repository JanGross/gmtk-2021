using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NodeButton : MonoBehaviour
{
    public Node node;
    public Node.Direction direction;
    // Start is called before the first frame update
    void Start()
    {
        if (node.connections[(int)direction] == null)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    private void FixedUpdate()
    {

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == gameObject.transform)
                {
                    Debug.Log(string.Format("Button down on {0}", direction));
                    node.MoveToDirection(direction);    
                }
            }
        }
    }

    private void OnMouseOver()
    {
       
    }
}
