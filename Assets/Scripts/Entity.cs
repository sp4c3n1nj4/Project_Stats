using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public virtual void Update()
    {

    }

    //base behaviour of on death function
    public virtual void EntityDeath()
    {
        throw new System.NotImplementedException();
    }

    //base function of take damage function
    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        Mathf.Clamp(health,0,maxHealth);
        if (health == 0)
        {
            EntityDeath();
        }
    }
}
