using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCard : MonoBehaviour
{
    public GameObject grabScene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            grabScene.SetActive(true);
            GameManager.Instance.HasCard = true;
        }
    }
}
