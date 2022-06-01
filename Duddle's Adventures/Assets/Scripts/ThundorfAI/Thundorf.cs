using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Thundorf : MonoBehaviour
{
    public float knockbackPower = 100;
    public float knockbackDuration = 1;
    public float HP = 10;
    [SerializeField] private Image healtbar;

    public GameObject Lightning;

    public float FireRate;
    public float nextFire;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        anim.SetBool("dmged", true);
        FireRate = 1f;
        nextFire = Time.time;
        HP -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("dmged", false);
        healtbar.fillAmount = HP / 13;

        CheckTimeToFire();
        if (HP <= 0)
        {
            anim.SetBool("died", true);
            Destroy(gameObject);
            SceneManager.LoadScene("Victory");
        }
    }
    void CheckTimeToFire()
    {
        if(Time.time > nextFire)
        {
            Instantiate(Lightning, transform.position, Quaternion.identity);
            nextFire = Time.time + FireRate;
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
