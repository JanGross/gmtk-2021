using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBox : MonoBehaviour
{
    public SpotInteractions spot;
    public GameObject door;
    public GameObject fakeDoor;
    public GameObject visuals;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       
            if(spot.hasBeenUnlocked)
            {
                visuals.SetActive(true);
            // door.transform.Rotate(0, 90, 0, Space.Self);
            door.SetActive(false);
            fakeDoor.SetActive(true);

                GetComponent<Collider>().enabled = false;
            }
   
    }
}
