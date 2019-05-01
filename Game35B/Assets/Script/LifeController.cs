using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class LifeController : MonoBehaviour
{

    public float LifeLevel;

    private float counter;

    private bool isHealing;
    // Start is called before the first frame update
    void Start()
    {
        LifeLevel = 100.0f;
        counter = 0;
        isHealing = false;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if (counter > 5 && isHealing == false)
        {
            StartCoroutine(Healing());
            counter = 0;
        }
    }

    public void setDamage(float damage)
    {
        if(LifeLevel>=0)
            LifeLevel -= damage;
        if (LifeLevel < 0)
            LifeLevel = 0;
    }

    public void restoreLife(float life)
    {

    }
    
    private IEnumerator Healing()
    {
        Debug.Log("Leczenie");

        isHealing = true;

        while (LifeLevel < 100)
        {
            LifeLevel += 0.1f;
            yield return new WaitForSeconds(1f);
        }

        isHealing = false;
    }

  
}
