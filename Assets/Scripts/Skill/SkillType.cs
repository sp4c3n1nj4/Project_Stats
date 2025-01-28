using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    Swipe,
    Thrust
}

public enum AimType
{
    movementAim,
    mouseAim
}

public enum AItype
{
    Hug,
    Distance,
    Flee
}

public enum DropType
{
    Experience,
    Gold,
    Healing,
    Loot1
}

public class EnemyConstants
{
    public const float EnemyAggroRange = 20f;
}
