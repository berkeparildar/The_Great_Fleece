using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;

    private Animator _animator;
    private Vector3 _target;
    private static readonly int Walk = Animator.StringToHash("walk");
    public GameObject coin;
    private AudioSource _audioSource;
    private bool _coinTossed = true;
    public List<GuardAI> guards;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = transform.GetChild(0).GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayOrigin, out var hitInfo))
            {
                _agent.SetDestination(hitInfo.point);
                _animator.SetBool(Walk, true);
                _target = hitInfo.point;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayOrigin, out var hitInfo))
            {
                if (_coinTossed)
                {
                    Instantiate(coin, hitInfo.point, Quaternion.identity);
                    _animator.SetTrigger("throw");
                    _audioSource.Play();
                    for (int i = 0; i < guards.Count; i++)
                    {
                        guards[i].NotifyGuards();
                    }
                    _coinTossed = false;
                }
            }
        }

        if (Vector3.Distance(transform.position, _target) < 1)
        {
            _animator.SetBool(Walk, false);
        }
    }
}
