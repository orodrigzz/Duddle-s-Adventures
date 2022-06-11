using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealtbar;
    [SerializeField] private Image currenthealthBar;

    // Start is called before the first frame update
    void Start()
    {
        currenthealthBar.fillAmount = playerHealth.currHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currHealth / 10;
    }
}
