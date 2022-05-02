using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KingSlimo : MonoBehaviour
{
    public float HP = 10;
    public float knockbackPower = 100;
    public float knockbackDuration = 1;
    public GameObject Heart;

    public void TakeDamage(float damage)
    {
        HP -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Level2");
        }

    }

    //for knockback
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(PlayerController.instance.Knowckback(knockbackDuration, knockbackPower, this.transform));
        }
    }
}