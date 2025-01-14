using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public float cooldown = 1;
    private float timer = 0;

    public float cdr = 0;

    private void Update()
    {
        SkillTimer();
    }

    public int CalculateDamage()
    {
        int damage = 0;
        //fix this
        return damage;
    }

    public void SkillTimer()
    {
        timer += Time.deltaTime;
        if (timer >= (cooldown * (1 / (1 + cdr))))
        {
            timer= 0;
            TriggerSkill();
        }
    }

    public virtual void TriggerSkill()
    {
        throw new System.Exception("Triggered Skill without type");
    }
}
