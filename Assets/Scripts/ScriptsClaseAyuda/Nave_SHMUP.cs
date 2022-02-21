using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed;
    public float shootRate = 0.5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawner;
    enum Movement { STILL, FORWARD, BACKWARD, UP, DOWN};
    private Movement mov;
    private bool shooting;
    private bool canShoot = true;

    private void Start () {
        mov = Movement.STILL;
        rb = GetComponent<Rigidbody2D> ();
    }

    private void Shoot () {
        if (shooting && canShoot) {
            StartCoroutine (FireRate ());
        }
    }

    private void FixedUpdate () {
        float delta = Time.fixedDeltaTime * 1000;

        switch (mov)
        {
            default:
                break;
            case Movement.FORWARD:
                rb.AddForce(transform.up * +speed / 50 * delta, ForceMode2D.Impulse);
                break;
            case Movement.BACKWARD:
                rb.AddForce(transform.up * -speed / 50 * delta, ForceMode2D.Impulse);
                break;
            case Movement.UP:
                rb.AddForce(transform.right * -speed / 50 * delta, ForceMode2D.Impulse);
                break;
            case Movement.DOWN:
                rb.AddForce(transform.right * +speed / 50 * delta, ForceMode2D.Impulse);
                break;

        }

        rb.AddForce (transform.up * speed);
    }

    public void Lose () {
        rb.velocity = Vector3.zero;
        transform.position = Vector3.zero;
    }

    private IEnumerator FireRate () {
        canShoot = false;
        var bullet = Instantiate (
            bulletPrefab,
            bulletSpawner.position,
            bulletSpawner.rotation
        );
        Destroy (bullet, 5);
        yield return new WaitForSeconds (shootRate);
        canShoot = true;
    }
}