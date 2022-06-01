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
    private Animator anim;

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
        anim.SetBool("dmged", false);
        healtbar.fillAmount = HP / 13;

        if (HP <= 0)
        {
            anim.SetBool("died", true);
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