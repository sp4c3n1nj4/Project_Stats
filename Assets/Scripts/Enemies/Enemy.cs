using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    //on death drops
    public Dictionary<DropType, float> OnDeathDrops;
    //movement
    public float moveSpeed;
    public AItype aItype;
    //attack
    public float attackDamage;
    public float attackSpeed;
    public SkillType skillType;

    private void Start()
    {
        EnemyManager.Enemies.Add(gameObject);
    }

    public override void EntityDeath()
    {
        DropOnDeath();
        EnemyManager.Enemies.Remove(gameObject);
        Destroy(gameObject);
    }

    public override void Update()
    {
        base.Update();
        //do movement
        //do attack
    }

    private void DropOnDeath()
    {
        foreach (DropType type in OnDeathDrops.Keys)
        {
            switch (type)
            {
                case DropType.Experience:
                    break;
                case DropType.Gold:
                    break;
                case DropType.Loot1:
                    break;
                default:
                    break;
            }
        }
    }
}
