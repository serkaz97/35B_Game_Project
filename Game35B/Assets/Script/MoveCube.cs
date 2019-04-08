using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public int Speed = 10;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward*Time.deltaTime*Speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * Speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * Speed*5);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.up * Time.deltaTime * Speed);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.useGravity = !rb.useGravity;
        }
    }
}
