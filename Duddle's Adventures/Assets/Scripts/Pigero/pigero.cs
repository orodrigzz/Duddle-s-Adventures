using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pigero : MonoBehaviour
{
    public float knockbackPower = 100;
    public float knockbackDuration = 1;
    public float HP = 3;
    public AudioSource daño;
    [SerializeField] private Image healtbar;
    private Animator anim;
    private int feedbackID;
    private bool dmged;

    private int diedID;
    private bool died;

    private Rigidbody2D rb2d;

    public float speed;

    [HideInInspector]
    public bool mustPatrol;
    public bool MoveRight;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage)
    {
        anim.SetBool("dmged", true);
        daño.Play();
        HP -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("dmged", false);
        healtbar.fillAmount = HP / 3;

        if (HP <= 0)
        {
            anim.SetBool("died", true);
            rb2d.constraints = RigidbodyConstraints2D.None;
            rb2d.mass = 55;
            speed = 0;
        }

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
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(PlayerController.instance.Knowckback(knockbackDuration, knockbackPower, this.transform));
        }

        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Scenario" || other.gameObject.tag == "Plataforma")
        {
            Destroy(gameObject);
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
}
