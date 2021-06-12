using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionPaddle : MonoBehaviour
{
    public void Switch()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void InteractNode()
    {
        this.GetComponent<Collider>().enabled = !this.GetComponent<Collider>().enabled;
        this.GetComponent<MeshRenderer>().enabled = !this.GetComponent<MeshRenderer>().enabled;

    }
}
