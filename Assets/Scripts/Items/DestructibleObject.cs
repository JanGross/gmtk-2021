using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = gameObject.transform.position; 
    }

    public void Respawn()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.transform.position = originalPosition;
        gameObject.transform.parent = null;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
