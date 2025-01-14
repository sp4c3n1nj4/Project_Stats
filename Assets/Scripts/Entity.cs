using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public virtual void Update()
    {

    }

    //base behaviour of on death function
    public virtual void EntityDeath()
    {
        throw new System.NotImplementedException();
    }

    //base function of take damage function
    public virtual void TakeDamage(int damage)
    {
        
    }
}
