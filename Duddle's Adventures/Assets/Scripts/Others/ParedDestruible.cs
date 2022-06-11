using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedDestruible : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BW_Bullet") || collision.gameObject.CompareTag("Green_bullet"))
        {
            Destroy(gameObject);
        }
    }
}
