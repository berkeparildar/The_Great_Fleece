using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public GameObject gameOverCutscene;

    private Animator _animator;

    private MeshRenderer _meshRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        _animator = transform.parent.GetComponent<Animator>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Color color = new Color(0.6f, 0.11f, 0.11f, 0.3f);
            _meshRenderer.material.SetColor("_TintColor", color);
            _animator.enabled = false;
            StartCoroutine(EndScene());
        }
    }

    IEnumerator EndScene()
    {
        yield return new WaitForSeconds(0.5f);
        gameOverCutscene.SetActive(true);
    }
}
