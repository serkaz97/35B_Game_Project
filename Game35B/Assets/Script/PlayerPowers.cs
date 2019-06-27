using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowers : MonoBehaviour
{
    public void PushEnemy()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.DrawLine(ray.origin, hit.point);

            if (hit.transform.CompareTag("Enemy"))
            {
                hit.transform.GetComponent<Enemy>().Push();
            }
        }
    }

    public void PullEnemy()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.DrawLine(ray.origin, hit.point);

            if (hit.transform.CompareTag("Enemy"))
            {
                hit.transform.GetComponent<Enemy>().Pull();
            }
        }
    }
}
