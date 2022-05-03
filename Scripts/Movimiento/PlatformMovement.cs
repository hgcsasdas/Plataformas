using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public GameObject ObjetoAmover;
    public Transform StartPoint;
    public Transform EndPoint;

    public float speed;

    private Vector3 MoverHacia;



    private void Start()
    {
        MoverHacia = EndPoint.position;
    }


    private void Update()
    {
        ObjetoAmover.transform.position = Vector3.MoveTowards(ObjetoAmover.transform.position, MoverHacia, speed * Time.deltaTime);
        if (ObjetoAmover.transform.position == EndPoint.position)
        {
            MoverHacia = StartPoint.position;
        }
        if(ObjetoAmover.transform.position == StartPoint.position)
        {
            MoverHacia = EndPoint.position; 
        }
    }
}
