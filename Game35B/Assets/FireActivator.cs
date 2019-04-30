using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActivator : MonoBehaviour
{
    private ParticleSystem flames;
    private AudioSource audioSource;
    private LifeController lc;

    public AudioClip fire;
    public bool isPlayerOn;
    public float Power = 5.0f;

    void Start()
    {

        audioSource = gameObject.GetComponent<AudioSource>();
        flames = gameObject.GetComponent<ParticleSystem>();
        flames.Stop();
        audioSource.clip = fire;
        isPlayerOn = false;
        audioSource.volume = 0f;
    }

    private IEnumerator MuteSound()
    {
        isPlayerOn = false;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= Time.deltaTime * 0.5f;
            yield return null;
        }

        flames.Stop();

    }

    private void OnTriggerEnter(Collider other)
    {
        isPlayerOn = true;
        flames.Play();
        audioSource.volume = 1.0f;
        PlayFireSound();
        lc = GameObject.FindWithTag("PlayerStats").GetComponent<LifeController>();
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(MuteSound());
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