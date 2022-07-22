using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chicken1 : MonoBehaviour
{
    public Animator animator;
    int targetangle = 0;
    public float rotate_speed = 0.1f;
    private void Update()
    {
        if(transform.rotation.y > targetangle)
        {
            transform.Rotate(new Vector3(0, rotate_speed, 0));
        }else if(transform.rotation.y < targetangle)
        {
            transform.Rotate(new Vector3(0, -rotate_speed, 0));
        }
    }

    private void Start()
    {
        transform.rotation = new Quaternion(transform.rotation.x, (int)transform.rotation.y, transform.rotation.z, transform.rotation.w);
        animator = this.GetComponent<Animator>();
        StartCoroutine(enumerator());
    }

    
    IEnumerator enumerator()
    {

        int a = Random.Range(5, 15);
        //Debug.Log(a);
        animator.SetFloat("Speed", a / 10f);
        a = Random.Range(0, 10);
        if (a > 6)
        {
            targetangle = Random.Range(-180, 180);
        }

        yield return new WaitForSeconds(3);
        StartCoroutine(enumerator());
    }
}
