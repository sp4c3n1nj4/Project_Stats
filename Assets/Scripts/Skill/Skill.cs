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

    public PolygonCollider2D hitBox;

    private void Update()
    {
        SkillTimer();
    }

    public int CalculateDamage()
    {
        int damage = 0;
        //need to implement stat scaling here
        return damage;
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
}
