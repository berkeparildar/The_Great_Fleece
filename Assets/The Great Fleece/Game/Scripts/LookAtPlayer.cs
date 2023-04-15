using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private GameObject _player;

    public Transform startCamera;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        transform.position = startCamera.position;
        transform.rotation = startCamera.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_player.transform);
    }
}
