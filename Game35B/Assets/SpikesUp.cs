using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SpikesUp : MonoBehaviour
{
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(spikesUp());
    }

    private IEnumerator spikesUp()
    {
        float up = 3;
        while (gameObject.transform.localPosition.y < startPos.y + up)
        {
            gameObject.transform.Translate(Vector3.up * 6f * Time.deltaTime);
            yield return null;
        }
        while (gameObject.transform.localPosition.y > startPos.y)
        {
            gameObject.transform.Translate(Vector3.up * -1.5f * Time.deltaTime);
            yield return null;
        }


    }
}
