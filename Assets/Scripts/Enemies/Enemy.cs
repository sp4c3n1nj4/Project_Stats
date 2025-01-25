using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    //on death drops
    public Dictionary<DropType, float> OnDeathDrops;
    //movement
    public float moveSpeed;
    public AItype aitype;
    //attack
    public float attackDamage;
    public float attackSpeed;
    public SkillType skillType;

    private void Start()
    {
        TrySetUpMovement();
        //EnemyManager.Enemies.Add(gameObject);
    }

    private void TrySetUpMovement()
    {
        AIMovement aiMovement;
        if (gameObject.TryGetComponent(out aiMovement))
        {
            aiMovement.SetUpMovementValues(moveSpeed, aitype, gameObject.GetComponent<Rigidbody2D>());
        }
    }

    public override void EntityDeath()
    {
        DropOnDeath();
        EnemyManager.Enemies.Remove(gameObject);
        Destroy(gameObject);
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
                case DropType.Healing:
                    break;
                case DropType.Loot1:
                    break;
                default:
                    break;
            }
        }
    }
}
