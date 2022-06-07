using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image Fade_;
    public float valoralfad;

    // Start is called before the first frame update
    void Start()
    {
        Fade_.color = new Color(0, 0, 0, 1);
        valoralfad = 0;
    }

    private void FixedUpdate()
    {
        float valoralfa = Mathf.Lerp(Fade_.color.a, valoralfad, .05f);
        Fade_.color = new Color(0, 0, 0, valoralfa);
    }
}