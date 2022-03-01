using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.right, distance,whatIsSolid);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Slimos"))
            {
                //Debug.Log("Enemy must take dmg");
                hitInfo.collider.GetComponent<slimo>() .TakeDamage(damage);
                DestroyProjectile();
            }
            

            if (hitInfo.collider.CompareTag("Pigero"))
            {
                //Debug.Log("Enemy must take dmg");
                hitInfo.collider.GetComponent<pigero>().TakeDamage(damage);
                DestroyProjectile();
            }
            
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
