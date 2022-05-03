using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigero : MonoBehaviour
{
    public float knockbackPower = 100;
    public float knockbackDuration = 1;
    public float HP = 3;
    public AudioSource da�o;

    // Start is called before the first frame update

    public void TakeDamage(float damage)
    {
        da�o.Play();
        HP -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            da�o.Play();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(PlayerController.instance.Knowckback(knockbackDuration, knockbackPower, this.transform));
        }
    }
}
