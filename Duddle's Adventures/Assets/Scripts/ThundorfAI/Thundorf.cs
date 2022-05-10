using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Thundorf : MonoBehaviour
{
    public float knockbackPower = 100;
    public float knockbackDuration = 1;
    public float HP = 3;
    public GameObject Heart;

    public GameObject Lightning;

    public float FireRate;
    public float nextFire;

    // Start is called before the first frame update

    public void TakeDamage(float damage)
    {
        FireRate = 1f;
        nextFire = Time.time;
        HP -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTimeToFire();
        if (HP <= 0)
        {
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
