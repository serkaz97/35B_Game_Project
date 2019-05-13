using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{

    public float LifeLevel;

    private float counter;

    private bool isHealing;

    void Start()
    {
        LifeLevel = 100.0f;
        counter = 0;
        isHealing = false;
    }

    void Update()
    {
        if (LifeLevel < 100 && counter <= 0)
        {
            counter = 5;
        }
        else
        {
            counter -= Time.deltaTime;
        }

        if (counter < 0 && isHealing == false && LifeLevel < 100)
        {
            StartCoroutine(Healing());
        }
    }

    public void setDamage(float damage)
    {
        if (LifeLevel >= 0)
            LifeLevel -= damage;
        if (LifeLevel < 0)
        {
            LifeLevel = 0;
            Death();
        }

    }

    public void restoreLife(float life)
    {

    }
    
    private IEnumerator Healing()
    {
        Debug.Log("Leczenie");

        float currentHealth = LifeLevel;
        isHealing = true;

        while (LifeLevel < 100)
        {
            LifeLevel += 0.5f;
            yield return new WaitForSeconds(0.5f);

            if (LifeLevel < currentHealth)
            {
                break;
            }

            currentHealth = LifeLevel;
        }

        isHealing = false;
    }

    private void Death()
    {
        Debug.Log("Player Is Dead");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
