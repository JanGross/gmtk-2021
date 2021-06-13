using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotInteractions : MonoBehaviour
{
    public float interactionDistance = 5;
    public GameObject hintMissing;
    public GameObject hintUnlocked;
    public GameObject hint;
    public GameObject visuals;
    private GameManager gameManager;
    private Renderer renderer;


    public bool hasBeenUnlocked;

    public PlayerInteractable interactable;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        renderer = gameObject.GetComponent<Renderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (hasBeenUnlocked)
        {
            interactable.hint = hintUnlocked;
            hint.SetActive(false);
            hintMissing.SetActive(false);
            visuals.SetActive(true);
            return;
        }
        if (gameManager.playerHasBattery)
        {
            interactable.hint = hint;
            hintUnlocked.SetActive(false);
            hintMissing.SetActive(false);
        }
        else
        {
            interactable.hint = hintMissing;
            hint.SetActive(false);
            hintUnlocked.SetActive(false);
        }
    }

    public void PlayerInteract()
    {
        Debug.Log("Trying to modify spot");
        if (gameManager.playerHasBattery)
        {
            hasBeenUnlocked = true;
        }
    }

}
