using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActivator : MonoBehaviour
{
    private bool isPlayerOn;
    public float Power;
    private ParticleSystem ps;

    private LifeController lc;
    // Start is called before the first frame update
    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
        ps.Stop();
        isPlayerOn = false;
        Power = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (isPlayerOn && lc.LifeLevel>=0)
        {
            lc.LifeLevel-=Power*Time.deltaTime;
        }*/

    }

    private void OnTriggerEnter(Collider other)
    {
        isPlayerOn = true;
        ps.Play();
        lc = GameObject.FindWithTag("PlayerStats").GetComponent<LifeController>();
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerOn = false;
        ps.Stop();
        
    }

    private void OnTriggerStay(Collider other)
    {
        lc.setDamage(Power * Time.deltaTime);
    }
}
