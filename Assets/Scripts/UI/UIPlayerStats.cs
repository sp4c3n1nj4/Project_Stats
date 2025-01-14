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

    private void OnEnable()
    {
        PopulateStatList();
    }

    private void OnDisable()
    {
        for (int i = playerStatsUIContent.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(playerStatsUIContent.transform.GetChild(i).gameObject);
        }
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
