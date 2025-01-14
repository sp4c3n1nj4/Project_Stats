using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset actions;
    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private Rigidbody2D rb;

    InputAction moveAction;
    Vector2 moveVector;

    private void Start()
    {
        actions.FindActionMap("ActionMap").Enable();
        moveAction = actions.FindActionMap("ActionMap").FindAction("WASD");
    }

    private void Update()
    {          
        moveVector = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * speed;
    }
}
