using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionActivator : MonoBehaviour
{
    private ParticleSystem explosion;
    private AudioSource audioSource;
    private LifeController lc;

    public float Power = 5.0f;
    public AudioClip fire;

    private bool canActivate = true;

    void Start()
    {
        explosion = gameObject.GetComponent<ParticleSystem>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = fire;
        audioSource.volume = 0f;
        explosion.Stop();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") && canActivate)
        {
            lc = GameObject.FindWithTag("PlayerStats").GetComponent<LifeController>();
            canActivate = false;
            explosion.Play();
            audioSource.Play();
            audioSource.volume = 1.0f;
            lc.setDamage(Power * 10);
        }
    }

}