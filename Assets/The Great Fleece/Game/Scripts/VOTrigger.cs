using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VOTrigger : MonoBehaviour
{
    public AudioClip coinClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && coinClip != null)
        {
            AudioManager.Instance.PlayVoiceOver(coinClip);
        }
    }
}
