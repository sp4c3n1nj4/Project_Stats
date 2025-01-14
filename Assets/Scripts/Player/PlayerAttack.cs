using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerAttack : MonoBehaviour
{


    private List<Skill> skills = new List<Skill>();

    [SerializeField]
    private Transform aimTransform;
    public float aimAngleOffset;

    private void Update()
    {
        AimTowards(GetMouseWorldPosition());
    }

    private void AimTowards(Vector3 target)
    {
        Vector3 aimDirection = (target - aimTransform.position).normalized;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        aimTransform.eulerAngles = new Vector3(0, 0, angle + aimAngleOffset);
    }

    private Vector3 GetMouseWorldPosition()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 vector = Camera.main.ScreenToWorldPoint(mousePos);
        return vector;
    }
}
