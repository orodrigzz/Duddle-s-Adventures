using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigero : MonoBehaviour
{

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
}
