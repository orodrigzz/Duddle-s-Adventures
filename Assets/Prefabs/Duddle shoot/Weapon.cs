using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Sprite greenGun;
    public Sprite yellowGun;
    public Sprite redGun;


    [SerializeField] PlayerController player;

    public float offset;

    private float timeBtwShots;
    public float startTimeBtwShots;
    [SerializeField] SpriteRenderer spr_render;

    public GameObject projectile;
    public Transform shotPoint;

    Vector3 difference;
    float rotZ;
    float currentAngle;
    // Update is called once per frame
    void Update()
    {
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        currentAngle = transform.rotation.eulerAngles.z;

        if ((currentAngle < 90.0f && currentAngle > 0.0f) ||
            (currentAngle > 270.0f && currentAngle < 360.0f)
            )
        {
            spr_render.flipY = false;
            player.FlipX(false);
        }
        else
        {
            spr_render.flipY = true;
            player.FlipX(true);
        }

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //if (green == 1)
            //{
                spr_render.sprite = greenGun;
            //}
            //if (yellow == 1)
            //{
            //    spr_render.sprite = yellowGun;
            //}
            //if (red == 1)
            //{
            //    spr_render.sprite = redGun;
            //}
        }
    }
}
