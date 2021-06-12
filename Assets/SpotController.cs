using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotController : MonoBehaviour
{
    public GameObject sphere;

    private float speed = 6f;
    private float revSpeed = 5f;

    private float moveInput;
    private float turnInput;

    private float turnSpeed = 50f;

    private void Start()
    {
        sphere.transform.parent = null;
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        moveInput *= moveInput > 0 ? speed : revSpeed;
;
        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        sphere.transform.Rotate(0, newRotation, 0, Space.Self);

        transform.position = sphere.transform.position;
        transform.rotation = sphere.transform.rotation;
    }

    private void LateUpdate()
    {
        sphere.transform.Translate(Vector3.forward * moveInput * Time.deltaTime, Space.Self);
    }
}
