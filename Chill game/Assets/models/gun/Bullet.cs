using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="Enemy")
        {
            col.transform.parent.gameObject.GetComponent<HEalth>().health-=damage;
        }
        Destroy(gameObject);
    }
}
