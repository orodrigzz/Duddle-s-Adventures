using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigero : MonoBehaviour
{
    public float knockbackPower = 100;
    public float knockbackDuration = 1;
    public float HP = 3;
    // Start is called before the first frame update

    public void TakeDamage(int damage)
    {
        HP -= damage;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Dmg(float _dmg)
    {
        HP -= _dmg;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(PlayerController.instance.Knowckback(knockbackDuration, knockbackPower, this.transform));
        }
    }
}
