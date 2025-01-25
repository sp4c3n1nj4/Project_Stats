using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class AIMovement : MonoBehaviour
{
    private float moveSpeed;
    private AItype aitype;
    private Rigidbody2D rb;

    private bool isAggro;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void SetUpMovementValues(float _speed, AItype _aitype, Rigidbody2D _rb)
    {
        moveSpeed = _speed;
        aitype = _aitype;
        rb = _rb;
    }

    private void Update()
    {
        FindDistanceToPlayer();
    }

    private void FindDistanceToPlayer() 
    {
        Vector3 position = gameObject.transform.position;
        Vector3 playerPosition = PlayerExperience.PlayerExperienceInstance.gameObject.transform.position;

        if (Vector3.Distance(position, playerPosition) <= EnemyConstants.EnemyAggroRange)
        {
            isAggro = true;
        }
    }

    private void FixedUpdate()
    {
        if (!isAggro)
            return;

        switch (aitype)
        {
            case AItype.Hug:
                HugMovement();
                break;
            case AItype.Distance:
                DistanceMovement();
                break;
            case AItype.Flee:
                FleeMovement();
                break;
            default:
                break;
           
        }
    }

    private void HugMovement()
    {
        Vector3 position = gameObject.transform.position;
        Vector3 playerPosition = PlayerExperience.PlayerExperienceInstance.gameObject.transform.position;

        Vector3 moveVector = playerPosition - position;

        rb.velocity = moveVector.normalized * moveSpeed;
    }

    private void DistanceMovement()
    {
        throw new NotImplementedException();
    }

    private void FleeMovement()
    {
        throw new NotImplementedException();
    }
}
