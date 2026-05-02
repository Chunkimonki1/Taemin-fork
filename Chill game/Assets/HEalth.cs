using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class HEalth : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public int score;
    public GameObject deathEffect;

    void Update()
    {
        if (health < 1)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
