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


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
    }

    private IEnumerator Pause()
    {
        yield return new WaitForSeconds(1.3f);
        _rb.isKinematic = true;
        _agent.enabled = true;
    }

    void Update()
    {
        if (_target)
        {
            if(Vector3.Distance(transform.position, _target.position) > 3f)
            {
                _agent.SetDestination(_target.position);
                _agent.isStopped = false;
            }
            else
            {
                _agent.isStopped = true;
            }
        }
    }

    public void Push()
    {
        Vector3 direction = transform.position - GameManager.Instance.GetPlayer().transform.position;
        direction.Normalize();
        _rb.isKinematic = false;
        _agent.enabled = false;
        _rb.AddForce(direction * 7f, ForceMode.Impulse);
        StartCoroutine(Pause());
    }

    public void Pull()
    {
        Vector3 direction = GameManager.Instance.GetPlayer().transform.position - transform.position;
        direction.Normalize();
        _rb.isKinematic = false;
        _agent.enabled = false;
        _rb.AddForce(direction * 7f, ForceMode.Impulse);
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
