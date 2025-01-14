using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerHealth : Entity
{
    [SerializeField]
    private GameObject hitDamageNumberPrefab;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        VisualizeDamageTaken(damage);   
    }

    void VisualizeDamageTaken(int damage)
    {
        Color colour = Color.white;

        GameObject prefab = Instantiate(hitDamageNumberPrefab, this.gameObject.transform);
        prefab.GetComponent<TextMeshProUGUI>().color = colour;
        prefab.GetComponent<TextMeshProUGUI>().text = damage.ToString();
    }

    public override void EntityDeath()
    {
        throw new NotImplementedException();
    }
}
