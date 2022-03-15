using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimo : MonoBehaviour
{
    public float HP = 4;
    public float knockbackPower = 100;
    public float knockbackDuration = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
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
    //for knockback
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(PlayerController.instance.Knowckback(knockbackDuration, knockbackPower, this.transform));
        }
    }
}
