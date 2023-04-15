using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private Transform _myCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Camera.main.transform.position = _myCamera.position;
            Camera.main.transform.rotation = _myCamera.rotation;
            Debug.Log("Trigger Activated");
        }
    }
}   
