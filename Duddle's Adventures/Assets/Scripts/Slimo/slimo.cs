using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slimo : MonoBehaviour
{
    public float HP = 4;
    public float knockbackPower = 100;
    public float knockbackDuration = 1;
    [SerializeField] private Image healtbar;
    private Animator anim;


    public float speed;

    [HideInInspector]
    public bool mustPatrol;
    public bool MoveRight;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        anim.SetBool("dmged", true);
        HP -= damage;        
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(2, 2);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-2, 2);
        }

        anim.SetBool("dmged", false);
        healtbar.fillAmount = HP / 3;

        if (HP <= 0)
        {
            anim.SetBool("died", true);
            speed = 0;
            StartCoroutine(WaitForDestroy());

        }

    }

    //for knockback
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(PlayerController.instance.Knowckback(knockbackDuration, knockbackPower, this.transform));
        }
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Ground"))
        {
            if (MoveRight)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
        }
    }

    private IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
