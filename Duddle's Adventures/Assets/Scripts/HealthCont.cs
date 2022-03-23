using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCont : MonoBehaviour
{
    public float healthv = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().AddHealth(healthv);
            gameObject.SetActive(false);
        }
    }
}
