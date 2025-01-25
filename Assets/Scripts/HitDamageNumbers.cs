using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitDamageNumbers : MonoBehaviour
{
    private float durationSeconds = 0.5f;

    [SerializeField]
    private TextMeshPro textMeshPro;

    public void SetUpHitDamageNumbers(float _value, Color _colour)
    {
        textMeshPro.text = "-" + _value.ToString();
        textMeshPro.color = _colour;
    }

    private void Update()
    {
        gameObject.transform.position += new Vector3(-0.2f, 0.2f) * Time.deltaTime;
    }

    private void OnEnable()
    {
        Destroy(gameObject, durationSeconds);
    }
}
