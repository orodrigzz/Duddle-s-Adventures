using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public GameObject ObjetoAMover;

    public Transform StartPoint;

    public Transform EndPoint;

    public float speed;

    private Vector3 MoverHacia;

    // Start is called before the first frame update
    void Start()
    {
        MoverHacia = EndPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObjetoAMover.transform.position = Vector3.MoveTowards(ObjetoAMover.transform.position, MoverHacia, speed * Time.deltaTime);

        if(ObjetoAMover.transform.position == EndPoint.position)
        {
            MoverHacia = StartPoint.position;
        }

        if (ObjetoAMover.transform.position == StartPoint.position)
        {
            MoverHacia = EndPoint.position; 
        }
     }
}
