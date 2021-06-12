using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RobotArmController : MonoBehaviour
{

    public GameObject target;
    public float armSpeed = 1;
    public float armRotationSpeed = 10;
    public Vector3 targetConstraints;
    public GameObject targetMarker;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        targetMarker.transform.position = new Vector3(target.transform.position.x, transform.position.y + .5f, target.transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Hoch/Runter
        if (Keyboard.current.ctrlKey.isPressed && target.transform.position.y > transform.position.y)
        {
            target.transform.localPosition += Vector3.down * Time.deltaTime * armSpeed;
        }

        if (Keyboard.current.shiftKey.isPressed && target.transform.localPosition.y < targetConstraints.y)
        {
            target.transform.localPosition += Vector3.up * Time.deltaTime * armSpeed;
        }

        //Debug.Log(-targetConstraints.z);
        //Left/Right
        if (Keyboard.current.aKey.isPressed && target.transform.localPosition.z > -targetConstraints.z)
        {
            target.transform.localPosition += Vector3.back * Time.deltaTime * armSpeed;
        }

        if (Keyboard.current.dKey.isPressed && target.transform.localPosition.z < targetConstraints.z)
        {
            target.transform.localPosition += Vector3.forward * Time.deltaTime * armSpeed;
        }

        //Left/Right
        if (Keyboard.current.qKey.isPressed)
        {
            transform.Rotate(0.0f, armRotationSpeed * Time.deltaTime, 0.0f, Space.Self);
        }   

        if (Keyboard.current.eKey.isPressed)
        {
            transform.Rotate(0.0f, -armRotationSpeed * Time.deltaTime, 0.0f, Space.Self);
        }

        //Forwards/Backwards
        if (Keyboard.current.wKey.isPressed && target.transform.localPosition.x > -targetConstraints.x)
        {
            target.transform.localPosition += Vector3.left * Time.deltaTime * armSpeed;
        }

        if (Keyboard.current.sKey.isPressed && target.transform.localPosition.x < -3.5f)
        {
            target.transform.localPosition += Vector3.right * Time.deltaTime * armSpeed;
        }
    }
}
