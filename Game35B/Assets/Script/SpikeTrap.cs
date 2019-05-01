using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{

    private LifeController lc;

    public float Power;
    // Start is called before the first frame update
    void Start()
    {
        Power = 5;
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        lc.setDamage(Power*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        lc = GameObject.FindWithTag("PlayerStats").GetComponent<LifeController>();
        lc.setDamage(Power * Time.deltaTime);
    }
}
