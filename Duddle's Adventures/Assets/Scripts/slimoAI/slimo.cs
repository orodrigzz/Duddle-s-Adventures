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
        healtbar.fillAmount = HP / 3;

        if (HP <= 0)
        {
            anim.SetBool("died", true);
            Destroy(gameObject);
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
}
