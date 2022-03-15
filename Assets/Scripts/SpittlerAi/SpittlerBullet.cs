using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpittlerBullet : MonoBehaviour
{
    public float damage;
    public float speed;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        DestroyProjectile();
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
