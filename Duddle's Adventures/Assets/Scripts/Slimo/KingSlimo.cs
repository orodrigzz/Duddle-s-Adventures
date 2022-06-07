using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KingSlimo : MonoBehaviour
{
    public float HP = 8;
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
        healtbar.fillAmount = HP / 10;

        if (HP <= 0)
        {
            anim.SetBool("died", true);
            StartCoroutine(WaitForLVL2());
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

    private IEnumerator WaitForLVL2()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        Victory.Play();
        SceneManager.LoadScene("Level2");
    }
}