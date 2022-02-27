using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float startHealth;
    public float currHealth;

    private void Awake()
    {
        currHealth = startHealth;

    }

    public void Dmg(float _dmg)
    {
        currHealth -= _dmg;
         
        if (currHealth > 0)
        {
            //daño
        }
        else
        {
            //muere
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Dmg(1);

    }
}
