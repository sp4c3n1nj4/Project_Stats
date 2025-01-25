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

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        VisualizeDamageTaken(damage);   
    }

    void VisualizeDamageTaken(float damage)
    {
        Color colour = Color.red;
       
        GameObject prefab = Instantiate(hitDamageNumberPrefab, this.gameObject.transform);
        HitDamageNumbers script = prefab.GetComponent<HitDamageNumbers>();

        script.SetUpHitDamageNumbers(damage, colour);
    }

    public override void EntityDeath()
    {
        throw new NotImplementedException();
    }
}
