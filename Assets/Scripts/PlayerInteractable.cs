using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractable : MonoBehaviour
{
    public float interactionDistance = 10;
    public GameObject hint;
    private GameManager gameManager;
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        renderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()   
    {
        if (hint)
        {
            hint.SetActive(false);
        }

        if (renderer.isVisible)
        {
            bool foundPlayer = false;
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactionDistance);
            foreach (Collider collider in colliders)
            {
                if(collider.gameObject.tag == "Player")
                {
                    foundPlayer = true;
                    break;
                }
            }

            if (foundPlayer)
            {
                if(hint)
                {
                    hint.SetActive(true);
                }

                //Debug.Log("Switch is visible and in range");
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    gameObject.SendMessage("PlayerInteract");
                }
            }
        } 
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }
}
