using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public float interactionDistance = 5;
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

    }

    private void FixedUpdate()
    {
        hint.SetActive(false);

        if(gameManager.playerHasBattery) { return; }
        if (renderer.isVisible)
        {
            if (Vector3.Distance(transform.position, gameManager.player.transform.position) <= interactionDistance)
            {
                hint.SetActive(true);
                hint.transform.rotation = Quaternion.LookRotation(hint.transform.position - gameManager.playerCamera.transform.position);

                if (UnityEngine.InputSystem.Keyboard.current.eKey.wasPressedThisFrame)
                {
                    gameManager.playerHasBattery = true;
                    gameObject.SetActive(false);
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }
}
