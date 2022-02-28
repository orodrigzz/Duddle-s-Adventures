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
         
        if (currHealth > 0)
        {
            //daño
        }
        else
        {
            //muere
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //    Dmg(1);

        if(currHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slimos"))
        {
            Dmg(1);
        }
        if (collision.gameObject.CompareTag("Pigero"))
        {
            Dmg(1);
        }
    }
}
