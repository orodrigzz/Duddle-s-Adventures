using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KingSlimo : MonoBehaviour
{
    public float HP = 10;
    public float knockbackPower = 100;
    public float knockbackDuration = 1;
    public AudioSource Victory;
    [SerializeField] private Image healtbar;

    public void TakeDamage(float damage)
    {
        HP -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        healtbar.fillAmount = HP / 10;

        if (HP <= 0)
        {
            Victory.Play();
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