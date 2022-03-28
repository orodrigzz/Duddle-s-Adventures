using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Sprite greenGun;
    public Sprite yellowGun;
    public Sprite redGun;
    public Sprite gun;

    private int green = 0;
    private int red = 0;
    private int yellow = 0;
    //public int balas = 20;
    //private bool chargedbullet;

    [SerializeField] PlayerController player;

    public float offset;

    private float timeBtwShots;
    public float startTimeBtwShots;
    [SerializeField] SpriteRenderer spr_render;

    public GameObject projectile;
    public GameObject bullet_gr;
    public GameObject bullet_red;
    public GameObject bullet_yell;
    public GameObject bullet_btw;
    public Transform shotPoint;

    Vector3 difference;
    float rotZ;
    float currentAngle;

    [SerializeField] private Image Green;
    [SerializeField] private Image Yellow;
    [SerializeField] private Image Red;

    [SerializeField] private Image Green_;
    [SerializeField] private Image Yellow_;
    [SerializeField] private Image Red_;

    void Start()
    {
        //chargedbullet = false;
    }

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
            //if (balas >= 1)
            //{
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(projectile, shotPoint.position, transform.rotation);
                    timeBtwShots = startTimeBtwShots;
                    //balas--;
                }
            //}
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (green == 1)
            {
                spr_render.sprite = greenGun;
                projectile = bullet_gr;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (yellow == 1)
            {
                spr_render.sprite = yellowGun;
                projectile = bullet_yell;
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (red == 1)
            {
                spr_render.sprite = redGun;
                projectile = bullet_red;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            spr_render.sprite = gun;
            projectile = bullet_btw;
        }

        if (green == 1)
        {
            Green_.fillAmount = 0;
        }
        if (yellow == 1)
        {
            Yellow_.fillAmount = 0;
        }
        if (red == 1)
        {
            Red_.fillAmount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GreenCont")
        {
            Destroy(collision.gameObject);
            green++;
        }
        if (collision.tag == "YellowCont")
        {
            Destroy(collision.gameObject);
            yellow++;
        }
        if (collision.tag == "RedCont")
        {
            Destroy(collision.gameObject);
            red++;
        }
        //if (collision.tag == "ChargedBullet")
        //{
        //    Destroy(collision.gameObject);
        //    chargedbullet = true;
        //}
    }
}

