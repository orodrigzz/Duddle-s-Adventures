using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimo : MonoBehaviour
{
    public float HP = 4;
    // Start is called before the first frame update
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
}
