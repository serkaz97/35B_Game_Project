using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActivator : MonoBehaviour
{
    public bool isPlayerOn;
    public float Power;
    private ParticleSystem ps;
    private AudioSource audioSource;
    private LifeController lc;

    [SerializeField] private AudioClip fire;

    // Start is called before the first frame update
    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
        audioSource = gameObject.GetComponent<AudioSource>();      
        ps.Stop();
        isPlayerOn = false;
        Power = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        isPlayerOn = true;
        ps.Play();
        PlayFireSound();
        lc = GameObject.FindWithTag("PlayerStats").GetComponent<LifeController>();
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerOn = false;
        ps.Stop();
        StopFireSound();
        //audioSource.Stop();
        
    }

    private void OnTriggerStay(Collider other)
    {
        lc.setDamage(Power * Time.deltaTime);
        
    }

    private void PlayFireSound()
    {
        audioSource.clip = fire;
        audioSource.Play();
        audioSource.loop = true;
    }

    private void StopFireSound()
    {
        audioSource.clip = fire;
        audioSource.loop = false;
    }
}
