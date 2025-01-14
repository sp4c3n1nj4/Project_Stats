using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerStatsCounter : MonoBehaviour
{
    public static PlayerStatsCounter Instance;
    [SerializeField]
    public static Dictionary<Enum,int> PlayerStatistics;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (PlayerStatistics == null)
        {
            PlayerStatistics = new Dictionary<Enum, int>();
        }
    }

    private void Start()
    {
        AddNewStat(BaseStats.strength, 1);
        AddNewStat(BaseStats.dexterity, 2);
        AddNewStat(BaseStats.intelligence, 3);
        AddNewStat(BaseStats.constitution, 4);
        AddNewStat(BaseStats.resilience, 5);

        print(PlayerStatistics.Count);
    }

    public void UpdatePlayerStats()
    {
        //call stat implement script
    }

    public void AddNewStat(Enum stat, int value = 0)
    {
        if (PlayerStatistics.ContainsKey(stat))
        {
            throw new Exception("Player already has stat: " + stat.ToString());
        }

        PlayerStatistics.Add(stat, value);
        UpdatePlayerStats();
    }

    public void RemoveStat(Enum stat)
    {
        if (!PlayerStatistics.ContainsKey(stat))
        {
            throw new Exception("Player does not have stat: " + stat.ToString());
        }

        PlayerStatistics.Remove(stat);
        UpdatePlayerStats();
    }

    public static void IncreaseStat(Enum stat, int value)
    {
        if (!PlayerStatistics.ContainsKey(stat))
        {
            throw new Exception("Player does not have stat: " + stat.ToString());
        }

        PlayerStatistics[stat] += value;
        Instance.UpdatePlayerStats();
    }

    public void DecreaseStat(Enum stat, int value)
    {
        if (!PlayerStatistics.ContainsKey(stat))
        {
            throw new Exception("Player does not have stat: " + stat.ToString());
        }

        PlayerStatistics[stat] -= value;
        UpdatePlayerStats();
    }

    public void OverrideStat(Enum stat, int value)
    {
        if (!PlayerStatistics.ContainsKey(stat))
        {
            throw new Exception("Player does not have stat: " + stat.ToString());
        }

        PlayerStatistics[stat] = value;
        UpdatePlayerStats();
    }
}
