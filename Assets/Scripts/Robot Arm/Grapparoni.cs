using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grapparoni : MonoBehaviour
{
    public float radius;
    public GameObject grabSpot;
    public GameObject grabbedObject;

    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    void DrawLineToClosest()
    {
        Collider[] items = Physics.OverlapSphere(grabSpot.transform.position, radius);
        if (items.Length < 1) { lineRenderer.enabled = false; return; }
        GameObject closest = items[0].gameObject;
        foreach (Collider item in items)
        {
            Rigidbody rb = item.gameObject.GetComponent<Rigidbody>();

            if (rb)
            {
                float dist = Vector3.Distance(item.transform.position, transform.position);
                if (dist < Vector3.Distance(closest.transform.position, transform.position))
                {
                    closest = item.gameObject;
                }
            }
        }
        Rigidbody closestRb = closest.transform.GetComponent<Rigidbody>();
        if (closestRb)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, grabSpot.transform.position);
            lineRenderer.SetPosition(1, closest.transform.position);
        } else
        {
            lineRenderer.enabled = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 directionVector = transform.parent.position - transform.parent.parent.position;
        transform.rotation = transform.parent.parent.rotation;//Quaternion.LookRotation(directionVector);


        DrawLineToClosest();


    }

    public void GrabClosest()
    {
        if (grabbedObject) //We already have stuff, let go!
        {
            grabbedObject.transform.SetParent(null);
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject = null;
            return;
        }

        Collider[] items = Physics.OverlapSphere(grabSpot.transform.position, radius);
        if (items.Length < 1) { return; }
        GameObject closest = items[0].gameObject;
        foreach (Collider item in items)
        {
            Rigidbody rb = item.gameObject.GetComponent<Rigidbody>();

            if(rb)
            {
                float dist = Vector3.Distance(item.transform.position, transform.position);
                if (dist < Vector3.Distance(closest.transform.position, transform.position)) {
                    closest = item.gameObject;
                }
            }
        }

        Rigidbody closestRb = closest.transform.GetComponent<Rigidbody>();
        if (closestRb)
        {
            closest.transform.SetParent(gameObject.transform);
            closest.transform.position = grabSpot.transform.position;
            closestRb.isKinematic = true;
            grabbedObject = closest.gameObject;

        }
    }

    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(grabSpot.transform.position, radius);

        Collider[] items = Physics.OverlapSphere(grabSpot.transform.position, radius);
        if(items.Length < 1) { return; }
        GameObject closest = items[0].gameObject;
        foreach (Collider item in items)
        {
            Rigidbody rb = item.gameObject.GetComponent<Rigidbody>();

            if (rb)
            {
                Debug.DrawRay(grabSpot.transform.position, (item.transform.position - grabSpot.transform.position), Color.gray);
                float dist = Vector3.Distance(item.transform.position, transform.position);
                if (dist < Vector3.Distance(closest.transform.position, transform.position))
                {
                    closest = item.gameObject;
                }
            } else
            {
                Debug.DrawRay(grabSpot.transform.position, (item.transform.position - grabSpot.transform.position), Color.red);
            }
            
        }
        Debug.DrawRay(grabSpot.transform.position, (closest.transform.position - grabSpot.transform.position), Color.green);
    }
}
