using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActivator : MonoBehaviour
{
    public bool isPlayerOn;
    public float Power;
    private ParticleSystem flames;
    private AudioSource audioSource;
    private LifeController lc;

    [SerializeField] private AudioClip fire;

    // Start is called before the first frame update
    void Start()
    {
        flames = gameObject.GetComponent<ParticleSystem>();
        audioSource = gameObject.GetComponent<AudioSource>();      
        flames.Stop();
        audioSource.clip = fire;
        
        isPlayerOn = false;
        Power = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.loop==false && audioSource.volume > 0f)
        {
            audioSource.volume -= 0.01f;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isPlayerOn = true;
        flames.Play();
        PlayFireSound();
        lc = GameObject.FindWithTag("PlayerStats").GetComponent<LifeController>();
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerOn = false;
        flames.Stop();
        StopFireSound();      
    }

    private void OnTriggerStay(Collider other)
    {
        lc.setDamage(Power * Time.deltaTime);       
    }

    private void PlayFireSound()
    {
        audioSource.volume = 1;
        audioSource.Play();
        audioSource.loop = true;
    }

    private void StopFireSound()
    {
        audioSource.loop = false;      
    }
}
