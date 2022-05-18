using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedDestruible : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BW_Bullet" || collision.tag == "Green_bullet")
        {
            Destroy(gameObject);
        }
    }
}
