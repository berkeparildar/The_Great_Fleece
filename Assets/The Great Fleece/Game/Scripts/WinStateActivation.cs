using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    public GameObject winScene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && GameManager.Instance == true)
        {
            winScene.SetActive(true);
        }
        else
        {
            Debug.Log("You must have the key.");
        }
    }
}
