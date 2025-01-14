using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerStatSelector : MonoBehaviour
{
    public static int statPoints;

    public void AddStatPoints(int value)
    {
        statPoints += value;
    }

    public void SpendStatPoint()
    {
        statPoints -= 1;

        PlayerStatsCounter.IncreaseStat(PlayerStatChoice(), 1);
    }

    public Enum PlayerStatChoice()
    {
        return BaseStats.resilience;
    }
}
