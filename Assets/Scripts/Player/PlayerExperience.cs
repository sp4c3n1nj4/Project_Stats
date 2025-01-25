using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerExperience : MonoBehaviour
{
    public static int playerLevel;
    public static int playerStatPoints;
    [SerializeField]
    private int maxPlayerLevel;

    public static float playerExperience;

    [SerializeField]
    private float ExperiencePerLevel;
    [SerializeField]
    private float ExperienceLevelGrowthPercent;

    //int: new player Level
    public static UnityEvent<int> PlayerLevelUp;
    //float: new current player experience
    public static UnityEvent<float> PlayerExpGain;

    public static PlayerExperience PlayerExperienceInstance { get; private set; }
    private void Awake()
    {
        if (PlayerLevelUp == null)
            PlayerLevelUp = new UnityEvent<int>();
        if (PlayerExpGain == null)
            PlayerExpGain = new UnityEvent<float>();

        // If there is an instance, and it's not me, delete myself.
        if (PlayerExperienceInstance != null && PlayerExperienceInstance != this)
        {
            Destroy(this);
        }
        else
        {
            PlayerExperienceInstance = this;
        }
    }

    private void Start()
    {
        PlayerExpGain.Invoke(playerExperience);
    }

    public void GainExperience(float experience)
    {
        playerExperience += experience;

        while (playerExperience >= CurrentLevelExperienceRequirement())
        {
            playerExperience -= CurrentLevelExperienceRequirement();

            IncreasePlayerLevel(1);
        }
        PlayerExpGain.Invoke(playerExperience);
    }

    public static float CurrentLevelExperienceRequirement()
    {
        return PlayerExperienceInstance.ExperiencePerLevel * (1 + PlayerExperienceInstance.ExperienceLevelGrowthPercent * playerLevel);
    }

    public void IncreasePlayerLevel(int value)
    {
        playerLevel += value;
        playerLevel = Mathf.Clamp(playerLevel, 1, maxPlayerLevel);
        playerStatPoints += value;
        playerStatPoints = Mathf.Clamp(playerStatPoints, 0, 9999);

        PlayerLevelUp.Invoke(playerLevel);
    }
}
