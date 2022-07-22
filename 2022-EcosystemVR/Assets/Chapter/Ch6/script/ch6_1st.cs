using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ch6_1st : MonoBehaviour
{
    public GameObject AxisObj, Camera, Cat;
    private Vector3 MoveDirection;
    public CharacterController CharacterController;
    float  a = 0.02f, v_max = 1 ,gravity = 200f;
    float Speed = 3;
    public static float Moving;

    

    private void Start()
    {
        Camera = GameObject.Find("Main Camera");
    }
    private void Update()
    {
        
        AxisObj.transform.localPosition = new Vector3(Camera.transform.forward.x, 0, Camera.transform.forward.z).normalized;

        if(Moving < v_max && HandAccelator.walk==1)
        {
            Moving = 1;
        }
        else
        {
            Moving -= a;
        }
        if (Moving < 0.01f) Moving = 0;
        if (Moving > 0.99f) Moving = 1;

        MoveDirection = Vector3.zero;
        if (CharacterController.isGrounded)
        {
            MoveDirection = new Vector3(AxisObj.transform.localPosition.x, 0, AxisObj.transform.localPosition.z);
            MoveDirection = transform.TransformDirection(MoveDirection);
            MoveDirection *= Speed * Moving;
            //Debug.Log(MoveDirection);
        }
        MoveDirection.y -= gravity * Time.deltaTime;
        CharacterController.Move(MoveDirection * Time.deltaTime);

        Transform newtransform = AxisObj.transform;
        newtransform.position = new Vector3(newtransform.position.x, Cat.transform.position.y, newtransform.position.z);

        
        Cat.transform.LookAt(newtransform);

    }

    



    


}
