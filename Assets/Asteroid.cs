using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroid : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed;
    public int scoreV = 100;

    public GameObject[] subAsteroids;
    public int numberOfAsteroids;
    // Start is called before the first frame update
    private void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }

    private void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag ("Bullet")) {
            GetComponent<ScoreManager>().AddScore(scoreV);
            Destroy (gameObject);
            Destroy (col.gameObject);
            for (var i = 0; i < numberOfAsteroids; i++) {
                Instantiate (
                    subAsteroids[Random.Range (0, subAsteroids.Length)],
                    transform.position,
                    Quaternion.identity
                );
            }
        }
        if (col.CompareTag ("Player")) {
            GetComponent<LevelManager>().CambiarLvl(LevelManager.Levels.GameOver);
            var asteroids = FindObjectsOfType<Asteroid>();
            for(var i = 0; i < asteroids.Length; i++) {
                Destroy(asteroids[i].gameObject);
            }
            col.GetComponent<Player>().Lose();
        }
    }

    private void Update()
    {
        rb.AddForce(transform.right * -speed / 50);

    }
}