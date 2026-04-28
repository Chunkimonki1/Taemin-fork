using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Animator anim;
    public Transform target;
    
    private Rigidbody rb;

    private float height;

    public float regularHieght;
    public float speed;
    public float attackRange;

    void Awake()
    {
        rb  = GetComponent<Rigidbody>();
    }


    void Update()
    {
        transform.position = new Vector3(transform.position.x, height, transform.position.z);

        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(target.transform.position.x, target.transform.position.z))<= attackRange)
        {
            Peck();
        } else
        {
            FollowPlayer();
        }
    } 

    void FollowPlayer()
    {
        transform.LookAt(target);
        rb.velocity=speed*transform.forward;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x*0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        height = Mathf.Lerp(height, regularHieght, Time.deltaTime);
    }

    void Peck()
    {
        rb.velocity = Vector3.zero;

        transform.LookAt(target);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x*0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        height = Mathf.Lerp(height, target.position.y+4, Time.deltaTime);

        if (Mathf.Abs(height-target.position.y)< 5)
        {
            anim.SetTrigger("Peck");
        }
    }
}
