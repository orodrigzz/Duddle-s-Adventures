using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green_Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    private float bwdamage = 1.25f;
    private float damage = 1;
    private float othdamage = 0.5f;
    int minval = 0;
    int maxval = 2;
    int randval;
    public LayerMask whatIsSolid;
    public GameObject SpriteHit1;
    public GameObject SpriteHit2;
    public GameObject SpriteHit3;

    // Start is called before the first frame update
    void Start()
    {
        GameObject showtut = GameObject.Find("tutorialbox");
        Tutorial tutscript = showtut.GetComponent<Tutorial>();

        for (int i = minval; i < maxval; i++)
        {
            randval = Random.Range(0, 2);
        }
        Invoke("DestroyProjectile", lifeTime);
    }


    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.right, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {

            if (randval == 0)
            {
                Instantiate(SpriteHit1, transform.position, new Quaternion(0, 0, 0, 0));
            }
            if (randval == 1)
            {
                Instantiate(SpriteHit2, transform.position, new Quaternion(0, 0, 0, 0));
            }
            if (randval == 2)
            {
                Instantiate(SpriteHit3, transform.position, new Quaternion(0, 0, 0, 0));
            }

            //Daño a King Slimo

            if (hitInfo.collider.CompareTag("KingSlimo"))
            {
                hitInfo.collider.GetComponent<KingSlimo>().TakeDamage(damage);
                DestroyProjectile();
            }
            DestroyProjectile();

            // Daño a blancos

            if (hitInfo.collider.CompareTag("Slimos"))
            {
                hitInfo.collider.GetComponent<slimo>().TakeDamage(bwdamage);
                DestroyProjectile();

                if (randval == 0)
                {
                    Instantiate(SpriteHit1, transform.position, new Quaternion(0, 0, 0, 0));
                }
                if (randval == 1)
                {
                    Instantiate(SpriteHit2, transform.position, new Quaternion(0, 0, 0, 0));
                }
                if (randval == 2)
                {
                    Instantiate(SpriteHit3, transform.position, new Quaternion(0, 0, 0, 0));
                }

            }
            DestroyProjectile();

            if (hitInfo.collider.CompareTag("Pigero"))
            {
                hitInfo.collider.GetComponent<pigero>().TakeDamage(bwdamage);
                DestroyProjectile();

                if (randval == 0)
                {
                    Instantiate(SpriteHit1, transform.position, new Quaternion(0, 0, 0, 0));
                }
                if (randval == 1)
                {
                    Instantiate(SpriteHit2, transform.position, new Quaternion(0, 0, 0, 0));
                }
                if (randval == 2)
                {
                    Instantiate(SpriteHit3, transform.position, new Quaternion(0, 0, 0, 0));
                }
            }
            DestroyProjectile();

            // Daño a verdes

            if (hitInfo.collider.CompareTag("SlimoGreen"))
            {
                hitInfo.collider.GetComponent<slimo>().TakeDamage(damage);
                DestroyProjectile();

                if (randval == 0)
                {
                    Instantiate(SpriteHit1, transform.position, new Quaternion(0, 0, 0, 0));
                }
                if (randval == 1)
                {
                    Instantiate(SpriteHit2, transform.position, new Quaternion(0, 0, 0, 0));
                }
                if (randval == 2)
                {
                    Instantiate(SpriteHit3, transform.position, new Quaternion(0, 0, 0, 0));
                }
            }
            DestroyProjectile();

            if (hitInfo.collider.CompareTag("PigeroGreen"))
            {
                hitInfo.collider.GetComponent<pigero>().TakeDamage(damage);
                DestroyProjectile();

                if (randval == 0)
                {
                    Instantiate(SpriteHit1, transform.position, new Quaternion(0, 0, 0, 0));
                }
                if (randval == 1)
                {
                    Instantiate(SpriteHit2, transform.position, new Quaternion(0, 0, 0, 0));
                }
                if (randval == 2)
                {
                    Instantiate(SpriteHit3, transform.position, new Quaternion(0, 0, 0, 0));
                }
            }
            DestroyProjectile();

            // Daño a otros colores

            if (hitInfo.collider.CompareTag("SlimoYellow") || hitInfo.collider.CompareTag("SlimoRed"))
            {
                hitInfo.collider.GetComponent<slimo>().TakeDamage(othdamage);
                DestroyProjectile();

                if (randval == 0)
                {
                    Instantiate(SpriteHit1, transform.position, new Quaternion(0, 0, 0, 0));
                }
                if (randval == 1)
                {
                    Instantiate(SpriteHit2, transform.position, new Quaternion(0, 0, 0, 0));
                }
                if (randval == 2)
                {
                    Instantiate(SpriteHit3, transform.position, new Quaternion(0, 0, 0, 0));
                }
            }
            DestroyProjectile();

            if (hitInfo.collider.CompareTag("PigeroRed") || hitInfo.collider.CompareTag("PigeroYellow"))
            {
                hitInfo.collider.GetComponent<pigero>().TakeDamage(othdamage);
                DestroyProjectile();

                if (randval == 0)
                {
                    Instantiate(SpriteHit1, transform.position, new Quaternion(0, 0, 0, 0));
                }
                if (randval == 1)
                {
                    Instantiate(SpriteHit2, transform.position, new Quaternion(0, 0, 0, 0));
                }
                if (randval == 2)
                {
                    Instantiate(SpriteHit3, transform.position, new Quaternion(0, 0, 0, 0));
                }
            }
            DestroyProjectile();


            if (hitInfo.collider.CompareTag("Tutorialmsg"))
            {
                hitInfo.collider.GetComponent<Tutorial>().ShowTutorial();

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
