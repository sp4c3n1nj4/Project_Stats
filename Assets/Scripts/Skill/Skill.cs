using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public AimType aimType;
    public SkillType skillType;

    public float cooldown = 1;
    private float timer = 0;
    public float hitBoxActiveSeconds = 1;

    public float damage;
    public BaseStats[] stats;

    public PolygonCollider2D hitBox;

    private void Update()
    {
        SkillTimer();
    }

    public float CalculateDamage()
    {
        float _damage = damage;
        //need to implement stat scaling here
        return _damage;
    }

    public void SkillTimer()
    {
        timer += Time.deltaTime;
        if (timer >= cooldown)
        {
            timer= 0;
            TriggerSkill();
        }
    }

    public virtual void TriggerSkill()
    {
        StartCoroutine(HitBoxActiveTimer(hitBoxActiveSeconds));
    }

    public IEnumerator HitBoxActiveTimer(float seconds)
    {
        hitBox.enabled = true;
        yield return new WaitForSeconds(seconds);
        hitBox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity entity;
        if (!collision.gameObject.CompareTag("Enemy"))
            return;
        if (collision.gameObject.TryGetComponent(out entity))
        {
            entity.TakeDamage(CalculateDamage());
            print("Hit enemy");
        }
    }
}
