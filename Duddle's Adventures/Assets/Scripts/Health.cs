using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    public AudioSource GameOver;
    [SerializeField] private float startHealth;
    public float currHealth;
    private Vector3 respawnpoint;

    private void Awake()
    {
        currHealth = startHealth;
    }
    private void Start()
    {
        respawnpoint = transform.position;
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
            GameOver.Play();
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
        if(currHealth <= 0)
        {
            GameOver.Play();
            SceneManager.LoadScene("Menu");
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
