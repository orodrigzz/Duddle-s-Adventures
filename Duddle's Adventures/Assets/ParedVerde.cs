using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedVerde : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Green_bullet")
        {
            Destroy(gameObject);
        }
    }

}
