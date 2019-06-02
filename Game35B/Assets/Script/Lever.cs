using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public float timer = 0;
    public KeyCode actionKey = KeyCode.E;
    public GameObject door1;
    public GameObject door2;
    public float doorSpeed = 0.1f;
    public Vector3 doorDirection = Vector3.up;
    public float doorValue = 5;
    public GameObject handle;
    public float handleSpeed = 2;
    public float handleRotation = 45;

    private bool _open = false;
    private float _handleRotationTemp;
    private float _doorValueTemp1;
    private float _doorValueTemp2;

    private void Start()
    {
        _handleRotationTemp = handleRotation;
        _doorValueTemp1 = doorValue;
        _doorValueTemp2 = doorValue;
    }

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(actionKey))
        {
            if (_open == false)
            {
                _open = true;
                if (timer > 0)
                {
                    StartCoroutine("Close");
                }
            }
            else
            {
                if (timer == 0)
                {
                    _open = false;
                }
            }
        }
    }

    IEnumerator Close()
    {
        yield return new WaitForSeconds(timer);
        _open = false;
    }

    private void FixedUpdate()
    {
        if(_open == true)
        {
            if (door1)
            {
                if (_doorValueTemp1 > 0)
                {
                    door1.transform.position += doorDirection * doorSpeed;
                    _doorValueTemp1 -= doorSpeed;
                }
            }
            if (door2)
            {
                if (_doorValueTemp2 > 0)
                {
                    door2.transform.position += -doorDirection * doorSpeed;
                    _doorValueTemp2 -= doorSpeed;
                }
            }

            if (_handleRotationTemp > 0)
            {
                handle.transform.Rotate(Vector3.left * handleSpeed);
                _handleRotationTemp -= handleSpeed;
            }
        }
        else if(_open == false)
        {
            if (door1)
            {
                if (_doorValueTemp1 < doorValue)
                {
                    door1.transform.position -= doorDirection * doorSpeed;
                    _doorValueTemp1 += doorSpeed;
                }
            }
            if (door2)
            {
                if (_doorValueTemp2 < doorValue)
                {
                    door2.transform.position -= -doorDirection * doorSpeed;
                    _doorValueTemp2 += doorSpeed;
                }
            }

            if (_handleRotationTemp < handleRotation)
            {
                handle.transform.Rotate(Vector3.right * handleSpeed);
                _handleRotationTemp += handleSpeed;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;

        if (door1)
        {
            Gizmos.DrawLine(transform.position, door1.transform.position);
        }

        if (door2)
        {
            Gizmos.DrawLine(transform.position, door2.transform.position);
        }
    }
}