using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> wayPoints;

    private NavMeshAgent _navMeshAgent;

    private int _currentTarget;

    private bool _targetReached;

    private float _distance;

    private bool _reverse;
    
    private Animator _animator;

    private GameObject _coin;

    private bool _coinExists;
    private bool _nearCoin = true;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_coinExists)
        {
            _nearCoin = false;
            _coin = GameObject.FindWithTag("Coin");
            var coinPosition = _coin.transform.position;
            _navMeshAgent.SetDestination(coinPosition);
            var distance = Vector3.Distance(transform.position, coinPosition);
            _animator.SetBool("walk", true);
            if (distance < 5)
            {
                _animator.SetBool("walk", false);
                StartCoroutine(LookAtCoin());
                _navMeshAgent.SetDestination(transform.position);
            }
        }
        if (wayPoints.Count > 0 && wayPoints[_currentTarget] != null && _nearCoin)
        {
            _navMeshAgent.SetDestination(wayPoints[_currentTarget].position);
            _distance = Vector3.Distance(transform.position, wayPoints[_currentTarget].position);

            if (_distance < 1 && _currentTarget == 0 || _currentTarget == wayPoints.Count - 1)
            {
                _animator.SetBool("walk", false);
            }
            else
            {
                _animator.SetBool("walk", true);
            }
            
            if (_distance < 1 && _targetReached == false)
            {
                if (wayPoints.Count > 1)
                {
                    if (_currentTarget == 0 || _currentTarget == wayPoints.Count - 1)
                    {
                        _targetReached = true;
                        StartCoroutine(IdleWait());
                    }
                    else
                    {
                        if (_reverse)
                        {
                            _reverse = false;
                            _currentTarget--;
                        }
                        else
                        {
                            _currentTarget++;
                        }
                    }
                }
            }
        }
    }

    public void NotifyGuards()
    {
        _coinExists = true;
    }

    IEnumerator IdleWait()
    {
        yield return new WaitForSeconds(Random.Range(0 ,5f));
        if (_currentTarget == 0)
        {
            yield return new WaitForSeconds(Random.Range(2, 5));
            _animator.SetBool("walk", false);
        }

        if (_currentTarget == wayPoints.Count - 1)
        {
            yield return new WaitForSeconds(Random.Range(2, 5));
            _animator.SetBool("walk", false);
        }
        
        if (_reverse)
        {
            _currentTarget--;
            if (_currentTarget == 0)
            {
                _reverse = false;
                _currentTarget = 0;
            }
        }
        else if (_reverse == false)
        {
            _currentTarget++;
            if (_currentTarget == wayPoints.Count)
            {
                _reverse = true;
                _currentTarget--;
            }
        }

        _targetReached = false;
    }
    
    IEnumerator LookAtCoin()
    {
        yield return new WaitForSeconds(5);
        _nearCoin = true;
        _coinExists = false;
    }
}

