using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistPlayerKiller : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem[] mistsSources;
    private LifeController lc;

    public float power=5;
    void Start()
    {
        for (int i = 0; i < mistsSources.Length; i++)
        {
            mistsSources[i].loop = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        lc.setDamage(power*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        lc = GameObject.FindWithTag("PlayerStats").GetComponent<LifeController>();
    }
}
