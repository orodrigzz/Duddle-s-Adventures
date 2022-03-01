using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Camera mainCam;
    private Vector3 mousePos;
    private Rigidbody2D rb;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slimos"))
            {
            GetComponent<slimo>().Dmg(1);
                //GameObject.FindGameObjectWithTag("Slimos").GetComponent<Dmg>(1);
            }
            //if (collision.gameObject.CompareTag("SlimoGreen"))
            //{
            //    GameObject.FindGameObjectWithTag("SlimoGreen").GetComponent<Dmg>(0.25f);
            //}
            //if (collision.gameObject.CompareTag("SlimoYellow"))
            //{
            //    GameObject.FindGameObjectWithTag("SlimoYellow").GetComponent<Dmg>(2);
            //}
            //if (collision.gameObject.CompareTag("SlimoRed"))
            //{
            //    GameObject.FindGameObjectWithTag("SlimoRed").GetComponent<Dmg>(2.5f);
            //}


            //if (collision.gameObject.CompareTag("Pigero"))
            //{
            //    GameObject.FindGameObjectWithTag("Pigero").GetComponent<Dmg>(1);
            //}
            //if (collision.gameObject.CompareTag("PigeroGreen"))
            //{
            //    GameObject.FindGameObjectWithTag("PigeroGreen").GetComponent<Dmg>(0.25f);
            //}
            //if (collision.gameObject.CompareTag("PigeroYellow"))
            //{
            //    GameObject.FindGameObjectWithTag("PigeroYellow").GetComponent<Dmg>(1.5f);
            //}
            //if (collision.gameObject.CompareTag("PigeroRed"))
            //{
            //    GameObject.FindGameObjectWithTag("PigeroRed").GetComponent<Dmg>(2);
            //}
     }
}
