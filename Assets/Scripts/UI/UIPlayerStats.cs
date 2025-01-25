using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPlayerStats : MonoBehaviour
{
    [SerializeField]
    private GameObject playerStatUIObject;
    [SerializeField]
    private Transform playerStatsUIContent;
    [SerializeField]
    private TextMeshProUGUI playerLevelText, playerStatPointText;

    private void Start()
    {
        PlayerExperience.PlayerLevelUp.AddListener(UpdateText);
    }

    private void OnEnable()
    {
        PopulateStatList();
        UpdateText();
    }

    private void OnDisable()
    {
        for (int i = playerStatsUIContent.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(playerStatsUIContent.transform.GetChild(i).gameObject);
        }
    }

    public void UpdateText(int level = 1)
    {
        playerLevelText.text = "Level: " + PlayerExperience.playerLevel.ToString();
        playerStatPointText.text = "Stat Point: " + PlayerExperience.playerStatPoints.ToString();
    }

    private void PopulateStatList()
    {        
        foreach (var playerStat in PlayerStatsCounter.PlayerStatistics)
        {
            GameObject newStat = Instantiate(playerStatUIObject);
            newStat.transform.SetParent(playerStatsUIContent, false);

            UIPlayerStatComponent playerStatComponent = newStat.GetComponent<UIPlayerStatComponent>();
            playerStatComponent.statKey = playerStat.Key;
            playerStatComponent.UpdateText();
        }
    }
}
