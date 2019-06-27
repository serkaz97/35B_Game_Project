using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 10f;

    public void Attack()
    {
        LifeController lc = GameObject.FindWithTag("PlayerStats").GetComponent<LifeController>();
        lc.setDamage(damage);
    }
}
