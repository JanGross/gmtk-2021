using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionPaddle : MonoBehaviour
{
    public void Switch()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
