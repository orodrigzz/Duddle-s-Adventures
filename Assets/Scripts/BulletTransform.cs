using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTransform : MonoBehaviour
{
    private SpriteRenderer spr_render;
    // Start is called before the first frame update
    void Start()
    {
        spr_render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.z > 90)
        {
            spr_render.flipX = true;
        }
    }

}
