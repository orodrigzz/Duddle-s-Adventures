using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{


    [SerializeField] private float startHealth;
    public float currHealth;

    private void Awake()
    {
        currHealth = startHealth;
    }

    public void Dmg(float _dmg)
    {
        currHealth -= _dmg;
        
    }

    private void Update()
    {
        if(currHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        /*if (collision.gameObject.CompareTag("SlimoRed"))
        {
            Dmg(2.5f);
        }*/


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
            Dmg(1.5f);
        }
        if (collision.gameObject.CompareTag("PigeroRed"))
        {
            Dmg(2);
        }

        if (collision.gameObject.CompareTag("SpittlerProjectile"))
        {
            Dmg(1f);
        }


        if (collision.gameObject.CompareTag("Floor"))
        {
            Dmg(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddHealth(float _value)
    {
        currHealth += _value;
    }
}
