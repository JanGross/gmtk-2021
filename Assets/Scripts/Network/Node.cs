using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
public class Node : MonoBehaviour
{
    public GameManager gameManager;
    public bool isActive = false;
    public enum Direction { Up, Down, Left, Right}
    public GameObject[] connections;
    public GameObject UI;

    public bool isUnlocked = true;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isUnlocked)
        {
            DisableNode();
        }   
    }

    public void SetActiveNode()
    {
        if (isActive) { return; }
        Debug.Log(string.Format("{0} became active node", gameObject.name));
        UI.SetActive(true);
        gameManager.previousNode = gameManager.activeNode.GetComponent<Node>();
        gameManager.activeNode = this.gameObject;
        gameManager.networkCamera.GetComponent<NetworkCamera>().targetPosition = new Vector3(transform.position.x, gameManager.networkCamera.transform.position.y, transform.position.z);
        isActive = true;
    }

    public void DisableNode()
    {
        UI.SetActive(false);
        isActive = false;
    }

    public void MoveToDirection(Direction dir)
    {
        Node nodeComp = connections[(int)dir].GetComponent<Node>();
        if (nodeComp)
        {
            nodeComp.SetActiveNode();
            DisableNode();
        } else
        {
            connections[(int)dir].SendMessage("InteractNode", this);
            gameManager.previousNode = this;
        }

        
    }
}
