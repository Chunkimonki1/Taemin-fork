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
    public float damage;

    public GameObject peckObject;

    void Awake()
    {
        rb  = GetComponent<Rigidbody>();
        target = GameObject.Find("Player").transform;
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

        height = Mathf.Lerp(height, target.position.y+9, Time.deltaTime);

        if (Mathf.Abs(height-target.position.y)< 11)
        {
            anim.SetTrigger("Peck");
        }

        AnimatorClipInfo[ ] clip = anim.GetCurrentAnimatorClipInfo(0);
        int frame = (int) (clip[0].weight * (clip[0].clip.length * clip[0].clip.frameRate));

        if (frame >= 12 & frame <= 16)
        {
            peckObject.SetActive(true);
            Collider[] peckTargets = Physics.OverlapSphere(peckObject.transform.position, 1);

            for(int i = 0; i < peckTargets.Length; i++) {
                if (peckTargets[i].gameObject.tag == "Player")
                {
                    peckTargets[i].transform.parent.GetComponent<HEalth>().health -= damage;
                }
            }
            
        } else
        {
            peckObject.SetActive(false);
        }
    }
}
