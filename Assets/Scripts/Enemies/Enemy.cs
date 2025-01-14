using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    private EnemyManager manager;

    public override void EntityDeath()
    {
        manager.Enemies.Remove(gameObject);
        Destroy(gameObject);
    }
}
