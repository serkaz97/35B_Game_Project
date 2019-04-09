using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using GameObject = UnityEngine.GameObject;

public class LightTrigger : MonoBehaviour
{
    public Light l;
    // Start is called before the first frame update
    private float startYPos;
    void Start()
    {
        l.enabled = false;
        startYPos = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (l.enabled)
        {
            if (gameObject.transform.position.y >= startYPos - 0.03)
            {
                gameObject.transform.Translate(Vector3.down*Time.deltaTime*0.25f);
            }
        }
        else if (!l.enabled)
        {
            if (gameObject.transform.position.y < startYPos)
            {
                gameObject.transform.Translate(Vector3.up * Time.deltaTime * 0.25f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        l.enabled = !l.enabled;
    }

   /* private void OnTriggerExit(Collider other)
    {
        l.enabled = false;
    }*/
}
