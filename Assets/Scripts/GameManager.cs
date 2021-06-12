using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public Camera[] cameras;
    public GameObject networkCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetActiveCamera(int cam)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i==cam) { 

            }
            cameras[i].enabled = (i == cam);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
