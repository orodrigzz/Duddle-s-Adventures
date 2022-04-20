using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitches : MonoBehaviour
{
    public GameObject bulletW;
    public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BW_Bullet"))
        {
            platform.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
