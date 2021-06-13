using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadend : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(string.Format("we collided with the thingie {0}", other.name));

        if (other.GetComponent<DestructibleObject>() != null)
        {
            DestructibleObject destructibleObject = other.GetComponent<DestructibleObject>();
            destructibleObject.Respawn();
        }
    }
}
