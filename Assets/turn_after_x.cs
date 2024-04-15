using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn_after_x : MonoBehaviour
{
    public bool turnOn = true;
    public float after = 0f; 

    public GameObject targetObject;

    private void OnEnable()
    {
        if (targetObject == null)
        {
            targetObject = gameObject;
        }
        Invoke("ToggleObject", after);
    }

    private void ToggleObject()
    {
        targetObject.SetActive(turnOn);
    }
}
