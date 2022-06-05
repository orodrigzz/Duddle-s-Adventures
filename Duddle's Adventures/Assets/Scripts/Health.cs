using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private BoxCollider2D box2D;
    public AudioSource death;
    [SerializeField] private float startHealth;
    public float currHealth;
    private Vector3 respawnpoint;
    private Animator anim;
    private Rigidbody2D Player;

    public Image Fade;
    public float valoralfad;

    void Start()
    {
        respawnpoint = transform.position;
        anim = GetComponent<Animator>();
        Player = GetComponent<Rigidbody2D>();
        box2D = GetComponent<BoxCollider2D>();
    }

    private void Awake()
    {
        currHealth = startHealth;
    }

    public void Dmg(float _dmg)
    {
        currHealth -= _dmg;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            Dmg(1);
            transform.position = respawnpoint;
            death.Play();
        }
        else if (collision.tag == "Checkpoint")
        {
            respawnpoint = transform.position;
        }

        if (collision.gameObject.CompareTag("Rayo"))
        {
            Dmg(1);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            currHealth = 10;
        }

        if (currHealth <= 0)
        {
            anim.SetBool("died", true);
            valoralfad = 2;
        }

    }

    private void FixedUpdate()
    {
        float valoralfa = Mathf.Lerp(Fade.color.a, valoralfad, .1f);
        Fade.color = new Color(0, 0, 0, valoralfa);

        if (valoralfa > 0.9f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slimos"))
        {
            Dmg(0.5f);
        }
        if (collision.gameObject.CompareTag("SlimoGreen"))
        {
            Dmg(1);
        }
        if (collision.gameObject.CompareTag("SlimoYellow"))
        {
            Dmg(2);
        }
        if (collision.gameObject.CompareTag("SlimoRed"))
        {
            Dmg(3);
        }


        if (collision.gameObject.CompareTag("Pigero"))
        {
            Dmg(0.5f);
        }
        if (collision.gameObject.CompareTag("PigeroGreen"))
        {
            Dmg(1);
        }
        if (collision.gameObject.CompareTag("PigeroYellow"))
        {
            Dmg(2f);
        }
        if (collision.gameObject.CompareTag("PigeroRed"))
        {
            Dmg(3);
        }

        if (collision.gameObject.CompareTag("SpittlerProjectile"))
        {
            Dmg(1f);
        }

    }

    public void AddHealth(float _value)
    {
        currHealth += _value;
    }

    public void HealPlayer(float _value)
    {
        if (startHealth == currHealth - 0.5f)
        {
            currHealth = currHealth + 0.5f;
        }
        if (currHealth < 5)
        {
            currHealth += _value;
        }

    }
}
