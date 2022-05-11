using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedVerde : MonoBehaviour
{
    private BoxCollider2D box2D;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        box2D = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Green_bullet")
        {
            Destroy(gameObject);
        }
    }

}
