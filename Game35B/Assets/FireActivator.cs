using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActivator : MonoBehaviour
{
    private ParticleSystem ps;
    private AudioSource audioSource;
    private LifeController lc;

    public bool isPlayerOn;
    public float Power = 5.0f;

    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
        audioSource = gameObject.GetComponent<AudioSource>();

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

        ps.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        isPlayerOn = true;
        ps.Play();
        audioSource.volume = 1.0f;

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
