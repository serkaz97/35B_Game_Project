using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionActivator : MonoBehaviour
{
    private ParticleSystem explosion;
    private AudioSource audioSource;
    private LifeController lc;

    public bool isPlayerOn;
    public float Power = 5.0f;
    public AudioClip fire;

    void Start()
    {
        explosion = gameObject.GetComponent<ParticleSystem>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = fire;
        isPlayerOn = false;
        audioSource.volume = 0f;
        explosion.Stop();
    }


    private void OnTriggerEnter(Collider other)
    {
        lc = GameObject.FindWithTag("PlayerStats").GetComponent<LifeController>();
        isPlayerOn = true;
        explosion.Play();
        audioSource.Play();
        audioSource.volume = 1.0f;
        lc.setDamage(Power*10);
    }

}