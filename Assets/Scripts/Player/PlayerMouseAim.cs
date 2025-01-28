using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouseAim : MonoBehaviour
{
    [SerializeField]
    GameObject mouseAim;

    void Update()
    {
        Vector3 player = this.transform.parent.position;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - player;

        mouseAim.transform.rotation = Quaternion.Euler(0, 0, -(Mathf.Atan2(mousePosition.x, mousePosition.y)) * Mathf.Rad2Deg);
    }
}
