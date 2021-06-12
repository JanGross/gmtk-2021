using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyer : MonoBehaviour
{
    public int conveyerSpeed = 0;
    public int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        // Debug-draw all contact points and normals
        foreach (ContactPoint contact in collision.contacts)
        {
            //Debug.Log(string.Format("Current Collider: {0} Position {1}", contact.otherCollider.name, contact.otherCollider.transform.position.magnitude));
            if(contact.otherCollider.GetComponent<Rigidbody>().velocity.magnitude < conveyerSpeed)
            {
                contact.otherCollider.GetComponent<Rigidbody>().AddForce(transform.forward * (conveyerSpeed * direction), ForceMode.Acceleration);

            }
        }
    }
}
