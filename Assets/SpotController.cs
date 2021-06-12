using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotController : MonoBehaviour
{
    public GameObject sphere;
    public GameObject visor;

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

    private float turnSpeed = 50f;

    private Light light;

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
;
        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        sphere.transform.Rotate(0, newRotation, 0, Space.Self);

        transform.position = sphere.transform.position;
        transform.rotation = sphere.transform.rotation;
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

        sphere.transform.Translate(Vector3.forward * moveInput * Time.deltaTime, Space.Self);
    }
}
