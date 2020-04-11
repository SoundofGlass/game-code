using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAngleMeasurement : MonoBehaviour
{

    
    public GameObject Origin;
    public GameObject leftHand;
    public GameObject rightHand;
    public float playerSpeed = 0f;
    public Vector3 prevPos;
    public Vector3 currentVel;

    //getlocalcontrollerposition()

    public void FixedUpdate()
    {
        //find velocity of both hands
        prevPos = transform.position;

        currentVel = (prevPos - transform.position) / Time.deltaTime;


        
    }
    public void Update()
    {
        
    }
}
