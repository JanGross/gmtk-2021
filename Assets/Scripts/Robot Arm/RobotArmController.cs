using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RobotArmController : MonoBehaviour
{

    public bool isInUse = false;

    public GameManager gameManager;
    public Grapparoni grabber;
    public CinemachineVirtualCamera localCamera;
    public GameObject target;
    public float armSpeed = 1;
    public float armRotationSpeed = 10;
    public Vector3 targetConstraints;
    public GameObject targetMarker;
    public GameObject hint;


    //Audio
    public AudioSource backgroundSource;
    public AudioSource sfxSource;
    public AudioSource interactSource;

    public AudioClip idleSound;
    public AudioClip interactSound;
    public AudioClip moveClip;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        target.GetComponent<Animator>().speed = 1f;
    }

    private void Update()
    {
        RaycastHit hit;
        Physics.Raycast(grabber.grabSpot.transform.position, Vector3.down, out hit, 10);

        hint.SetActive(isInUse);
        

        targetMarker.transform.position = new Vector3(grabber.grabSpot.transform.position.x, hit.point.y + 0.05f, grabber.grabSpot.transform.position.z);
    }

    public void InteractNode(Node pre)
    {
        gameManager.SetActiveCamera(localCamera);
        isInUse = true;
        target.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isInUse) { return; }

        bool isMoving = false;

        //return to network view with x
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            gameManager.SetActiveCamera(gameManager.networkCamera);
            target.GetComponent<Animator>().enabled = true;
            isInUse = false;
            gameManager.previousNode.SetActiveNode();
        }

        //return to network view with x
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !sfxSource.isPlaying)
        {
            grabber.GrabClosest();
            interactSource.clip = interactSound;
            interactSource.Play();

        }

        //Hoch/Runter
        if (Keyboard.current.ctrlKey.isPressed && target.transform.position.y > transform.position.y)
        {
            if(Physics.Raycast(grabber.grabSpot.transform.position, Vector3.down, .1f))
            {
                target.transform.localPosition -= Vector3.down * Time.deltaTime * armSpeed;
            }
            target.transform.localPosition += Vector3.down * Time.deltaTime * armSpeed;
            isMoving = true;
        }

        if (Keyboard.current.shiftKey.isPressed && target.transform.localPosition.y < targetConstraints.y)
        {
            target.transform.localPosition += Vector3.up * Time.deltaTime * armSpeed;
            isMoving = true;
        }

        //Debug.Log(-targetConstraints.z);
        //Left/Right
        /*if (Keyboard.current.aKey.isPressed && target.transform.localPosition.z > -targetConstraints.z)
        {
            target.transform.localPosition += Vector3.back * Time.deltaTime * armSpeed;
            isMoving = true;
        }

        if (Keyboard.current.dKey.isPressed && target.transform.localPosition.z < targetConstraints.z)
        {
            target.transform.localPosition += Vector3.forward * Time.deltaTime * armSpeed;
            isMoving = true;
        }*/

        //Left/Right
        if (Keyboard.current.qKey.isPressed)
        {
            transform.Rotate(0.0f, armRotationSpeed * Time.deltaTime, 0.0f, Space.Self);
            isMoving = true;
        }   

        if (Keyboard.current.eKey.isPressed)
        {
            transform.Rotate(0.0f, -armRotationSpeed * Time.deltaTime, 0.0f, Space.Self);
            isMoving = true;
        }

        //Forwards/Backwards
        if (Keyboard.current.wKey.isPressed && target.transform.localPosition.x > -targetConstraints.x)
        {
            target.transform.localPosition += Vector3.left * Time.deltaTime * armSpeed;
            isMoving = true;
        }

        if (Keyboard.current.sKey.isPressed && target.transform.localPosition.x < -3.5f)
        {
            target.transform.localPosition += Vector3.right * Time.deltaTime * armSpeed;
            isMoving = true;
        }

        if (!sfxSource.isPlaying && isMoving)
        {
            sfxSource.clip = moveClip;
            sfxSource.Play();
        }

        if(!isMoving)
        {
            sfxSource.Stop();
        }
    }
}
