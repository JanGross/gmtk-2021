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

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActiveNode()
    {
        if (isActive) { return; }
        Debug.Log(string.Format("{0} became active node", gameObject.name));
        isActive = true;
        UI.SetActive(true);
        gameManager.networkCamera.transform.position = new Vector3(transform.position.x, gameManager.networkCamera.transform.position.y, transform.position.z);
    }

    public void MoveToDirection(Direction dir)
    {
        connections[(int)dir].GetComponent<Node>().SetActiveNode();
        UI.SetActive(false);
        isActive = false;
    }
}
