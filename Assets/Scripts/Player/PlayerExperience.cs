using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerExperience : MonoBehaviour
{
    public static int playerLevel;
    [SerializeField]
    private int maxPlayerLevel;

    public static float playerExperience;

    [SerializeField]
    private float ExperiencePerLevel;
    [SerializeField]
    private float ExperienceLevelGrowthPercent;

    public UnityEvent<int> PlayerLevelUp;
    public UnityEvent<float,float> PlayerExpGain;

    private void Start()
    {
        PlayerExpGain.Invoke(playerExperience, CurrentLevelExperienceRequirement());
    }

    public void GainExperience(float experience)
    {
        playerExperience += experience;

        if (playerExperience >= CurrentLevelExperienceRequirement())
        {
            playerExperience -= CurrentLevelExperienceRequirement();

            IncreasePlayerLevel(1);
        }
        PlayerExpGain.Invoke(playerExperience, CurrentLevelExperienceRequirement());
    }

    public float CurrentLevelExperienceRequirement()
    {
        return ExperiencePerLevel * (1 + ExperienceLevelGrowthPercent * playerLevel);
    }

    public void IncreasePlayerLevel(int value)
    {
        playerLevel += value;
        playerLevel = Mathf.Clamp(playerLevel, 1, maxPlayerLevel);

        PlayerLevelUp.Invoke(playerLevel);
    }
}
