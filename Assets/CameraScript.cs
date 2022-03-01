using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Target;
    private Vector3 TargetPos;

    public float ForwardMove;
    public float Smoothing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TargetPos = new Vector3(Target.transform.position.x, Target.transform.position.y, transform.position.z);

        if(Target.transform.localScale.x == 1)
        {
            TargetPos = new Vector3(TargetPos.x + ForwardMove, TargetPos.y, transform.position.z); //Right
        }

        if (Target.transform.localScale.x == -1)
        {
            TargetPos = new Vector3(TargetPos.x - ForwardMove, TargetPos.y, transform.position.z); //Left
        }
        transform.position = Vector3.Lerp(transform.position, TargetPos, Smoothing * Time.deltaTime);
    }
}
