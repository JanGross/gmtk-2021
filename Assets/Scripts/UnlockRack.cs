using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockRack : MonoBehaviour
{

    private GameManager gameManager;
    private PlayerInteractable interactable;

    public GameObject hintMissing;
    public GameObject hintUnlocked;
    public GameObject hint;

    private bool hasBeenUnlocked = false;

    public Node[] unlockNodes;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        interactable = GetComponent<PlayerInteractable>();
    }

    // Update is called once per frame
    void Update()
    {

        if(hasBeenUnlocked)
        {
            interactable.hint = hintUnlocked;
            hint.SetActive(false);
            hintMissing.SetActive(false);
            return;
        }
        if(gameManager.playerHasUSB)
        {
            interactable.hint = hint;
            hintMissing.SetActive(false);
            hintUnlocked.SetActive(false);
        } else
        {
            interactable.hint = hintMissing;
            hint.SetActive(false);
        }
    }

    public void PlayerInteract()
    {
        Debug.Log("Trying to unlock rack");
        if(gameManager.playerHasUSB)
        {
            foreach (Node node in unlockNodes)
            {
                node.isUnlocked = true;
                hasBeenUnlocked = true;
            }
        }
    }
}
