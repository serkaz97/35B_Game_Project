using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private NavMeshAgent _agent;
    private Rigidbody _rb;
    private Animator _animator;


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
        _animator = transform.GetChild(0).GetComponent<Animator>();
    }

    private IEnumerator Pause()
    {
        yield return new WaitForSeconds(1.3f);
        _rb.isKinematic = true;
        _agent.enabled = true;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down * 2.3f);
    }

    void Update()
    {
        if (!IsGrounded())
        {
            _agent.enabled = false;
            _rb.isKinematic = false;
        }

        if (_agent.enabled)
        {
            if (_target)
            {
                if (Vector3.Distance(transform.position, _target.position) > 3f)
                {
                    _agent.SetDestination(_target.position);
                    _agent.isStopped = false;
                }
                else
                {
                    _agent.isStopped = true;
                    _animator.SetTrigger("attack");
                }
            }
            else
            {
                _agent.isStopped = true;
            }

            _animator.SetBool("moving", !_agent.isStopped);
        }
    }

    public void Push()
    {
        Vector3 direction = transform.position - GameManager.Instance.GetPlayer().transform.position;
        direction.Normalize();
        _rb.isKinematic = false;
        _agent.enabled = false;
        _rb.AddForce(direction * 13f, ForceMode.Impulse);
        _animator.SetBool("moving", false);
        StartCoroutine(Pause());
    }

    public void Pull()
    {
        Vector3 direction = GameManager.Instance.GetPlayer().transform.position - transform.position;
        direction.Normalize();
        _rb.isKinematic = false;
        _agent.enabled = false;
        _rb.AddForce(direction * 13f, ForceMode.Impulse);
        _animator.SetBool("moving", false);
        StartCoroutine(Pause());
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.transform.CompareTag("Player"))
        {
            _target = obj.transform;
        }
    }
}
