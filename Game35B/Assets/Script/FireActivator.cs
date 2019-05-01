using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActivator : MonoBehaviour
{
    private ParticleSystem flame;
    private AudioSource audioSource;
    private LifeController lc;

    public bool isPlayerOn;
    public float Power = 5.0f;
    public AudioClip fire;

    void Start()
    {
        flame = gameObject.GetComponent<ParticleSystem>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = fire;
        isPlayerOn = false;
        audioSource.volume = 0f;
        flame.Stop();
    }

    private IEnumerator MuteSound()
    {
        isPlayerOn = false;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= Time.deltaTime * 0.5f;
            yield return null;
        }

        flame.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        isPlayerOn = true;
        flame.Play();
        audioSource.Play();
        audioSource.volume = 1.0f;
        audioSource.loop = true;

        lc = GameObject.FindWithTag("PlayerStats").GetComponent<LifeController>();
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(MuteSound());
    }

    private void OnTriggerStay(Collider other)
    {
        lc.setDamage(Power * Time.deltaTime);
    }
}