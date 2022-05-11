using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pigero : MonoBehaviour
{
    public float knockbackPower = 100;
    public float knockbackDuration = 1;
    public float HP = 3;
    public AudioSource daño;
    [SerializeField] private Image healtbar;

    // Start is called before the first frame update

    public void TakeDamage(float damage)
    {
        daño.Play();
        HP -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        healtbar.fillAmount = HP / 3;

        if (HP <= 0)
        {
            daño.Play();
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
