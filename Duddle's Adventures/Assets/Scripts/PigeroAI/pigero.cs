using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pigero : MonoBehaviour
{
    public float knockbackPower = 100;
    public float knockbackDuration = 1;
    public float HP = 3;
    public AudioSource daño;
    [SerializeField] private Image healtbar;
    private Animator anim;
    private int feedbackID;
    private bool dmged;

    private int diedID;
    private bool died;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        anim.SetBool("dmged", true);
        daño.Play();
        HP -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("dmged", false);
        healtbar.fillAmount = HP / 3;

        if (HP <= 0)
        {
            anim.SetBool("died", true);
            daño.Play();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(PlayerController.instance.Knowckback(knockbackDuration, knockbackPower, this.transform));
        }
    }
}
