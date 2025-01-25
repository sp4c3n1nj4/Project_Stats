using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    [SerializeField]
    private float damage = 1;

    private float damageCooldownSeconds = 1;

    private bool canDoDamage = true;

    public void SetUpContactDamage(float _damage)
    {
        damage = _damage;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!canDoDamage)
            return;
        Entity entity;
        if (collision.gameObject.TryGetComponent(out entity))
        {
            entity.TakeDamage(damage);
            canDoDamage = false;
            StartCoroutine(CanDoDamageCooldown());
        }
    }

    private IEnumerator CanDoDamageCooldown()
    {
        yield return new WaitForSeconds(damageCooldownSeconds);
        canDoDamage = true;
    }
}
