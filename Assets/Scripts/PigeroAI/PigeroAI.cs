using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeroAI : MonoBehaviour
{
    // Start is called before the first frame update
    public float walkSpeed;

    [HideInInspector]
    public bool mustPatrol;
    public bool MoveRight;

    // Update is called once per frame
    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * walkSpeed, 0, 0);
            transform.localScale = new Vector2(2, 2);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * walkSpeed, 0, 0);
            transform.localScale = new Vector2(-2, 2);
        }
    }


    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Ground"))
        {
            if (MoveRight)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
        }
    }
}
