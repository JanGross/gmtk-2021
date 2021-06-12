using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotController : MonoBehaviour
{
    public GameObject sphere;
    public GameObject visor;

    public GameObject[] wheels;

    public AudioSource backgroundSource;
    public AudioSource sfxSource;
    public AudioSource interactSource;

    public AudioClip idleSound;
    public AudioClip interactSound;
    public AudioClip moveClip;

    private float speed = 6f;
    private float revSpeed = 5f;

    private float moveInput;
    private float turnInput;

    private float turnSpeed = 150f;

    private Light light;
    private bool blocked = false;

    private void Start()
    {
        sphere.transform.parent = null;

        backgroundSource.clip = idleSound;
        backgroundSource.Play();

        light = visor.GetComponentInChildren<Light>();

        StartCoroutine(FlashRoutine());
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        moveInput *= moveInput > 0 ? speed : revSpeed;

        if (moveInput != 0 && wheels.Length > 0)
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].transform.Rotate(0, 0, moveInput / 60 * 360 * Time.deltaTime);
            }
        }
;
        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        sphere.transform.Rotate(0, newRotation, 0, Space.Self);

        transform.position = sphere.transform.position;
        transform.rotation = sphere.transform.rotation;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1))
        {
            if (hit.transform.tag == "Wall")
            {
                blocked = true;
            }
            else
            {
                blocked = false;
            }
        }
        else
        {
            blocked = false;
        }
    }

    IEnumerator FlashRoutine()
    {
        Renderer renderer = visor.GetComponent<Renderer>();
 
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            renderer.material.SetColor("_EmissionColor", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));

            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
            renderer.material.SetColor("_EmissionColor", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
        }
    }
    private void LateUpdate()
    {
        if (moveInput != 0)
        {
            if (!sfxSource.isPlaying)
            {
                sfxSource.clip = moveClip;
                sfxSource.Play();
            }
        }
        else
        {
            sfxSource.Stop();
        }

        if (!blocked && moveInput > 0)
            sphere.transform.Translate(Vector3.forward * moveInput * Time.deltaTime, Space.Self);
    }
}
